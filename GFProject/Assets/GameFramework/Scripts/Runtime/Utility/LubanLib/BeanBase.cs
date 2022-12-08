using Bright.Serialization;
using UnityGameFramework.Runtime;

namespace Bright.Config
{
    public abstract class BeanBase : DataRowBase
    {
        public abstract int GetTypeId();
    }
}
