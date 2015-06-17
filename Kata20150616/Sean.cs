using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata20150616
{
    public class Sean
    {
        public static uint GCD(uint[] numbers)
        {
            // Return greatest common divisor for all numbers in the provided array.
            uint greatestNum = numbers.Min();
            uint gcd = greatestNum;
            bool greatest = false;

            while (!greatest)
            {
                greatest = true;
                foreach (uint number in numbers)
                {
                    if (number % gcd != 0)
                    {
                        greatest = false;
                        gcd--;
                        break;
                    }
                }
            }

            return gcd;
        }
    }
}
