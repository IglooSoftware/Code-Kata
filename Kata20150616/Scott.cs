using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata20150616
{
    public class Scott
    {
        public static uint GCD(uint[] numbers)
        {
            return realGDC(numbers);
        }

        public static uint realGDC(uint[] numbers)
        {
            if (numbers.Count() == 1)
            {
                return numbers[0];
            }

            int extra = numbers.Count() % 2;
            uint[] newNumbers = new uint[(numbers.Count() / 2) + extra];
            int iterations = (numbers.Count() / 2) + extra;
            uint[] tempNumbers = numbers;

            while (true)
            {

                Parallel.For(1, iterations + 1, i =>
                {
                    if (i == iterations && extra == 1)
                    {
                        newNumbers[i - 1] = gdc2(tempNumbers.ElementAt((i * 2) - 3), tempNumbers.ElementAt((i * 2) - 2));
                    }
                    else
                    {
                        newNumbers[i - 1] = gdc2(tempNumbers.ElementAt((i * 2) - 1), tempNumbers.ElementAt((i * 2) - 2));
                    }

                });

                if (newNumbers.Count() == 1)
                {
                    return newNumbers[0];
                }

                extra = newNumbers.Count() % 2;
                iterations = (newNumbers.Count() / 2) + extra;
                tempNumbers = newNumbers;
                newNumbers = new uint[(tempNumbers.Count() / 2) + extra];
            }
        }

        public static uint gdc2(uint first, uint second)
        {
            uint firstTemp = first;
            uint secondTemp = second;
            while (true)
            {
                if (firstTemp == secondTemp)
                {
                    return firstTemp;
                }
                else if (firstTemp > secondTemp)
                {
                    firstTemp = firstTemp - secondTemp;
                }
                else
                {
                    secondTemp = secondTemp - firstTemp;
                }
            }
        }
    }
}
