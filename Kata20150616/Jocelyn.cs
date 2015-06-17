using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata20150616
{
    class Jocelyn
    {
        private static uint GCD(uint a, uint b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }

            return a;
        }

        public static uint GCD(uint[] numbers)
        {
            uint gcd = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                gcd = GCD(gcd, numbers[i]);
            }

            return gcd;
        }
    }
}
