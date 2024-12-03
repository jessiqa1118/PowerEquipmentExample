using UnityEngine;
using PowerEquipment;

namespace Device
{
    [AddComponentMenu("Device/Shredder")]
    public class ShredderComponent : PowerConsumerComponent
    {
        [SerializeField] private int consumption = 320;
        public override Power Consumption => new(consumption);
    }
}