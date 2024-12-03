using UnityEngine;
using PowerEquipment;

namespace Device
{
    [AddComponentMenu("Device/Printer")]
    public class PrinterComponent : PowerConsumerComponent
    {
        [SerializeField] private int consumption = 500;
        public override Power Consumption => new(consumption);
    }
}