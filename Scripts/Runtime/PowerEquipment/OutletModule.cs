using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerEquipment
{
    public class OutletModule : IPowerSupplier
    {
        public static readonly Power DefaultCapacity = new(1500);

        private readonly List<IPowerSocket> _powerSockets;
        public Power Capacity { get; }
        public Power Consumption => new(_powerSockets.Sum(socket => socket.Consumption.Watts));

        public OutletModule(List<IPowerSocket> sockets, Power capacity)
        {
            _powerSockets = sockets;
            Capacity = capacity ?? DefaultCapacity;
        }

        public void Connect(int index, IPowerConsumer consumer)
        {
            ValidateSocketIndex(index);
            _powerSockets[index].Connect(consumer);
        }

        public void Disconnect(int index)
        {
            ValidateSocketIndex(index);
            _powerSockets[index].Disconnect();
        }

        private void ValidateSocketIndex(int index)
        {
            if (index < 0 || index >= _powerSockets.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), index, "指定されたソケットは存在しません。");
            }
        }
    }
}