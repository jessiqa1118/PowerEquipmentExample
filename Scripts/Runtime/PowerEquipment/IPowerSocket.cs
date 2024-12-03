namespace PowerEquipment
{
    public interface IPowerSocket
    {
        public bool IsConnected { get; }
        public Power Consumption { get; }

        public void Connect(IPowerConsumer consumer);
        public void Disconnect();
    }
}