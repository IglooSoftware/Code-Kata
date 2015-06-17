using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata20150616
{
    public class Matt
    {
        public static uint PairGCD(uint value1, uint value2)
        {
            while (value1 != 0 && value2 != 0)
                if (value1 > value2)
                    value1 %= value2;
                else
                    value2 %= value1;

            return value1 > value2 ? value1 : value2;
        }

        public static uint GCD(params uint[] numbers)
        {
            uint currentGCD = 0;
            if (numbers.Length > 0)
            {
                currentGCD = numbers[0];
                for (int i = 1; i < numbers.Length; i++)
                {
                    // Return greatest common divisor for all numbers in the provided array.
                    uint thisGCD = PairGCD(currentGCD, numbers[i]);
                    currentGCD = thisGCD < currentGCD ? thisGCD : currentGCD;
                    if (currentGCD == 1) break;
                }
            }
            return currentGCD;
        }
    }
}
