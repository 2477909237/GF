using GameFramework.DataTable;

namespace UnityGameFramework.Runtime
{
    public class LuBanDataTableHelper : DataTableHelperBase
    {
        public override bool ReadData(DataTableBase dataTable, string dataTableAssetName, object dataTableAsset, object userData)
        {
            throw new System.NotImplementedException();
        }

        public override bool ReadData(DataTableBase dataTable, string dataTableAssetName, byte[] dataTableBytes, int startIndex, int length,
            object userData)
        {
            throw new System.NotImplementedException();
        }

        public override bool ParseData(DataTableBase dataTable, string dataTableString, object userData)
        {
            throw new System.NotImplementedException();
        }

        public override bool ParseData(DataTableBase dataTable, byte[] dataTableBytes, int startIndex, int length, object userData)
        {
            throw new System.NotImplementedException();
        }

        public override void ReleaseDataAsset(DataTableBase dataTable, object dataTableAsset)
        {
            throw new System.NotImplementedException();
        }
    }
}