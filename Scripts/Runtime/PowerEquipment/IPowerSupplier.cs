namespace PowerEquipment
{
    public interface IPowerSupplier
    {
        public Power Capacity { get; }
        public Power Consumption { get; }
    }
}