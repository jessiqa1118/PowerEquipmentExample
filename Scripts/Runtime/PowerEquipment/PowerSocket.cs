namespace PowerEquipment
{
    public class PowerSocket : IPowerSocket
    {
        private IPowerConsumer _consumer;

        public bool IsConnected => _consumer != null;
        public Power Consumption => _consumer?.Consumption ?? new Power(0);

        public PowerSocket(IPowerConsumer consumer = null)
        {
            Connect(consumer);
        }

        public void Connect(IPowerConsumer consumer)
        {
            _consumer = consumer;
        }

        public void Disconnect()
        {
            _consumer = null;
        }
    }
}