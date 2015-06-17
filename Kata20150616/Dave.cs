using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata20150616
{
    static class Dave
    {
        static System.Collections.Concurrent.BlockingCollection<uint> lowValues = new System.Collections.Concurrent.BlockingCollection<uint>(new System.Collections.Concurrent.ConcurrentStack<uint>());
        public static uint GCD3Task(uint[] numbers) // Return greatest common divisor for all numbers in the provided array.
        {
            uint sample = numbers.First();
            uint oddset = sample % 2;

            if (numbers.All((x) => 0 == x % sample))
            {
                return sample;
            }

            using (Task<uint> lowSet = new Task<uint>(() => GCDlow(numbers)))
            {
                lowSet.Start();

                for (uint i = 2 + oddset; i <= (uint)Math.Sqrt(sample); i += 1 + oddset)
                {
                    if (0 == sample % i)
                    {
                        if (numbers.All((x) => 0 == x % (sample / i)))
                        {
                            lowValues.CompleteAdding();
                            lowSet.Wait();
                            return sample / i;
                        }

                        lowValues.Add(i);
                    }
                }

                lowValues.CompleteAdding();
                lowSet.Wait();

                return lowSet.Result;
            }
        }

        private static uint GCDlow(uint[] numbers) // Return greatest common divisor for all numbers in the provided array.
        {
            try
            {
                while (true)
                {
                    uint i = lowValues.Take();
                    if (numbers.All((x) => 0 == x % i))
                    {
                        return i;
                    }
                }
            }
            catch {  }

            lowValues.Dispose();

            return 1;
        }

        public static uint GCD2NoStorage(uint[] numbers) // Return greatest common divisor for all numbers in the provided array.
        {
            if (0 == numbers.Length)
            {
                throw new Exception("No u");
            }

            uint sample = numbers.First();
            uint oddset = sample % 2;
            uint lowResult = 1;

            if (numbers.All((x) => 0 == x % sample))
            {
                return sample;
            }

            for (uint i = 2 + oddset; i <= (uint)Math.Sqrt(sample); i += 1 + oddset)
            {
                if (0 == sample % i)
                {
                    if (numbers.All((num) => 0 == num % (sample / i)))
                    {
                        return sample / i;
                    }

                    if (numbers.All((num) => 0 == num % i))
                    {
                        lowResult = i;
                    }
                }
            }

            return lowResult;
        }

        public static uint GCD(uint[] numbers) // Return greatest common divisor for all numbers in the provided array.
        {
            if (0 == numbers.Length)
            {
                throw new Exception("No u");
            }

            uint sample = numbers.First();
            uint oddset = sample % 2;
            Stack<uint> lowValues = new Stack<uint>();

            if (numbers.All((x) => 0 == x % sample))
            {
                return sample;
            }

            for (uint i = 2 + oddset; i <= (uint)Math.Sqrt(sample); i += 1 + oddset)
            {
                if (0 == sample % i)
                {
                    if (numbers.All((num) => 0 == num % (sample / i)))
                    {
                        return sample / i;
                    }

                    lowValues.Push(i);
                }
            }

            while (0 < lowValues.Count)
            {
                uint i = lowValues.Pop();
                if (numbers.All((num) => 0 == num % i))
                {
                    return i;
                }
            }

            return 1;
        }
    }
}
