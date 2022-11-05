using GameFramework.DataTable;
using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public class LuBanDataTableHelper : DataTableHelperBase
    {
        public override bool ReadData(DataTableBase dataTable, string dataTableAssetName, object dataTableAsset, object userData)
        {
            return dataTable.ParseData((dataTableAsset as TextAsset)?.bytes);
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
            return dataTable.AddDataRow(dataTableBytes, startIndex, length, userData);
        }

        public override void ReleaseDataAsset(DataTableBase dataTable, object dataTableAsset)
        {
            GameEntry.GetComponent<ResourceComponent>().UnloadAsset(dataTableAsset);
        }
    }
}