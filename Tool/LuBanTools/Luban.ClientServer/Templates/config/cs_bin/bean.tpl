using Bright.Serialization;
using System.Collections.Generic;
{{
    name = x.name
    parent_def_type = x.parent_def_type
    export_fields = x.export_fields
    hierarchy_export_fields = x.hierarchy_export_fields
}}

{{cs_start_name_space_grace x.namespace_with_top_module}}
{{~if x.comment != '' ~}}
/// <summary>
/// {{x.escape_comment}}
/// </summary>
{{~end~}}
public partial class {{name}} : {{if parent_def_type}} {{x.parent}} {{else}} UnityGameFramework.Runtime.DataRowBase {{end}}
{

{{~if !x.is_abstract_type~}}
    public override int Id
        {
            get => {{x.id}};
        }
{{~end~}}


    {{~ for field in export_fields ~}}
{{~if field.comment != '' ~}}
    /// <summary>
    /// {{field.escape_comment}}
    /// </summary>
{{~end~}}
    public {{cs_define_type field.ctype}} {{field.convention_name}} { get; private set; }
    {{~if field.index_field~}} 
    public readonly Dictionary<{{cs_define_type field.index_field.ctype}}, {{cs_define_type field.ctype.element_type}}> {{field.convention_name}}_Index = new Dictionary<{{cs_define_type field.index_field.ctype}}, {{cs_define_type field.ctype.element_type}}>();
    {{~end~}}
    {{~if field.gen_ref~}}
    public {{field.cs_ref_validator_define}}
    {{~end~}}
    {{~if (gen_datetime_mills field.ctype) ~}}
    public long {{field.convention_name}}_Millis => {{field.convention_name}} * 1000L;
    {{~end~}}
    {{~if field.gen_text_key~}}
    public {{cs_define_text_key_field field}} { get; }
    {{~end~}}
    {{~end~}}




    public {{x.cs_method_modifier}} void TranslateText(System.Func<string, string, string> translator)
    {
        {{~if parent_def_type~}}
        base.TranslateText(translator);
        {{~end~}}
        {{~ for field in export_fields ~}}
        {{~if field.gen_text_key~}}
        {{cs_translate_text field 'translator'}}
        {{~else if field.has_recursive_text~}}
        {{cs_recursive_translate_text field 'translator'}}
        {{~end~}}
        {{~end~}}
    }

    public override string ToString()
    {
        return "{{full_name}}{ "
    {{~for field in hierarchy_export_fields ~}}
        + "{{field.convention_name}}:" + {{cs_to_string field.convention_name field.ctype}} + ","
    {{~end~}}
        + "}";
    }

    /// <summary>                                       
    /// 解析数据表行。                                         
    /// </summary>                                      
    /// <param name="dataRowString">要解析的数据表行字符串。</param>
    /// <param name="userData">用户自定义数据。</param>         
    /// <returns>是否解析数据表行成功。</returns>                  
    public override bool ParseDataRow(string dataRowString, object userData)
    {
        return base.ParseDataRow(dataRowString, userData);
    }    

    /// <summary>
    /// 解析数据表行。
    /// </summary>
    /// <param name="dataRowBytes">要解析的数据表行二进制流。</param>
    /// <param name="startIndex">数据表行二进制流的起始位置。</param>
    /// <param name="length">数据表行二进制流的长度。</param>
    /// <param name="userData">用户自定义数据。</param>
    /// <returns>是否解析数据表行成功。</returns>
    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        ByteBuf _buf = userData as ByteBuf;
        if (_buf == null)
            return false;
        {{~ for field in export_fields ~}}
        {{cs_deserialize '_buf' field.convention_name field.ctype}}
        {{~if field.index_field~}}
        foreach(var _v in {{field.convention_name}})
        { 
            {{field.convention_name}}_Index.Add(_v.{{field.index_field.convention_name}}, _v);
        }
        {{~end~}}
        {{~end~}}
        return true;
    }
}

{{cs_end_name_space_grace x.namespace_with_top_module}}