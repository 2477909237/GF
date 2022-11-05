using Bright.Serialization;
using UnityGameFramework.Runtime;

namespace Bright.Config
{
    public abstract class BeanBase : DataRowBase, ITypeId
    {
        public abstract int GetTypeId();
    }
}
