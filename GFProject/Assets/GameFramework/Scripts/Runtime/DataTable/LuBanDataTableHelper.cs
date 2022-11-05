using Bright.Serialization;
using GameFramework.DataTable;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public class LuBanDataTableHelper : DataTableHelperBase
    {
        public override bool ReadData(DataTableBase dataTable, string dataTableAssetName, object dataTableAsset, object userData)
        {
            TextAsset asset = dataTableAsset as TextAsset;
            if (asset == null || asset.bytes == null || asset.bytes.Length <= 0)
                return false;
            return dataTable.ParseData(asset.bytes, 0, asset.bytes.Length, userData);
        }

        public override bool ReadData(DataTableBase dataTable, string dataTableAssetName, byte[] dataTableBytes, int startIndex, int length,
            object userData)
        {
            return dataTable.ParseData(dataTableBytes, startIndex, length);
        }

        public override bool ParseData(DataTableBase dataTable, string dataTableString, object userData)
        {
            return dataTable.ParseData(System.Text.Encoding.UTF8.GetBytes(dataTableString));
        }

        public override bool ParseData(DataTableBase dataTable, byte[] dataTableBytes, int startIndex, int length, object userData)
        {
            var buf = new ByteBuf(dataTableBytes);
            for(int n = buf.ReadSize() ; n > 0 ; --n)
            {
                var a = buf.ReaderIndex;
                
                var result = dataTable.AddDataRow(dataTableBytes, buf.ReaderIndex, dataTableBytes.Length, userData);
                // if (!result)
                //     return false;
            }

            return true;
        }

        public override void ReleaseDataAsset(DataTableBase dataTable, object dataTableAsset)
        {
            GameEntry.GetComponent<ResourceComponent>().UnloadAsset(dataTableAsset);
        }
    }
}