using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata20150616
{
    public class Kiel
    {
        private static object _locker = new object();

        public static uint GCD(uint[] numbers)
        {
            if (numbers.Length == 1)
            {
                return numbers[0];
            }
            else if (numbers.Length == 2)
            {
                return GCD(numbers[0], numbers[1]);
            }

            var round = new List<uint>();

            var half = (int)Math.Floor(numbers.Length / 2.0);

            if (numbers.Length % 2 == 1)
            {
                round.Add(numbers.Last());
            }

            if (half > 5000)
            {
                Parallel.For(0, half, i =>
                {
                    var ret = GCD(numbers[i], numbers[half + i]);
                    lock (_locker)
                    {
                        round.Add(ret);
                    }
                });
            }
            else
            {
                for (int i = 0; i < half; i++)
                {
                    round.Add(GCD(numbers[i], numbers[half + i]));
                }
            }

            return GCD(round.ToArray());
        }

        //thank you Wikipedia
        private static uint GCD(uint u, uint v)
        {
            // simple cases (termination)
            if (u == v)
                return u;

            if (u == 0)
                return v;

            if (v == 0)
                return u;

            // look for factors of 2
            if ((~u & 1) == 1) // u is even
            {
                if ((v & 1) == 1) // v is odd
                    return GCD(u >> 1, v);
                else // both u and v are even
                    return GCD(u >> 1, v >> 1) << 1;
            }

            if ((~v & 1) == 1) // u is odd, v is even
                return GCD(u, v >> 1);

            // reduce larger argument
            if (u > v)
                return GCD((u - v) >> 1, v);

            return GCD((v - u) >> 1, u);
        }
    }
}
