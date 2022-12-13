#region << 文 件 说 明 >>

/*----------------------------------------------------------------
// 文件名称：DataTableComponentExtension
// 创 建 者：shuaibinliu
// 创建时间：2022年12月13日 星期二 15:50
// 文件版本：V1.0.0
//===============================================================
// 功能描述：
//		
//
//----------------------------------------------------------------*/

#endregion

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityGameFramework.Runtime;

public static class DataTableComponentExtension
{
    private const string dataPath = "Assets/Resources/LocalConfig";
    private const string bin = ".bytes";
    private const string json = ".json";
    private static bool isUseJson = false;
    
    public static void  LoadDataTable(this DataTableComponent dataTableComponent, Type t, string dataName, object userdata = null)
    {
        if (t == null || string.IsNullOrEmpty(dataName))
        {
            Log.Error("Load DataTable Failed type or dataName is null");
            return;
        }

        if (!dataName.EndsWith(bin) && !dataName.EndsWith(json))
        {
            if (isUseJson)
                dataName += json;
            else
            {
                dataName += bin;
            }
        }
        
        var fullPath = $"{dataPath}/{dataName}";
        var count = fullPath.Split('.').Length;
        if (count > 2)
        {
            Log.Error("Load DataTable Failed fullPath:" + fullPath);
            return;
        }
        var dataTable = dataTableComponent.CreateDataTable(t);
        dataTable.ReadData(fullPath, userdata);
    }
    
}
