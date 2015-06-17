using System;
using System.Collections.Generic;
using System.Numerics;


namespace Kata20150616
{
    public class Joe
    {
        public static uint GCD(uint[] numbers)
        {
            BigInteger result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (result == 1) break;
                result = BigInteger.GreatestCommonDivisor(result, numbers[i]);
            }

            return (uint)result;
        }
    }
}
