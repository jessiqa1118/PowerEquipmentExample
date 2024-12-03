using UnityEngine;

namespace PowerEquipment
{
    public abstract class PowerSupplierComponent : MonoBehaviour
    {
        public abstract int SocketCount { get; }
    }
}