using System;

namespace PowerEquipment
{
    public class Power
    {
        public int Watts { get; }

        public Power(int watts)
        {
            if (watts < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(watts), watts, "電力は0以上である必要があります。");
            }

            Watts = watts;
        }

        public static Power operator +(Power a, Power b)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (b == null) throw new ArgumentNullException(nameof(b));

            return new Power(a.Watts + b.Watts);
        }
    }
}