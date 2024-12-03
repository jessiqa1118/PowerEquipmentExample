using UnityEngine;

namespace PowerEquipment
{
    public abstract class PowerConsumerComponent : MonoBehaviour, IPowerConsumer
    {
        public abstract Power Consumption { get; }
    }
}