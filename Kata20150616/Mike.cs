using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata20150616
{
    public class Mike
    {
        private static List<uint> _primes = new List<uint>();

        public static uint GCD(uint[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return 0;
            }

            if (numbers.Length == 1)
            {
                return numbers[0];
            }

            GeneratePrimesUpTo((uint)Math.Sqrt(numbers.Max()));

            var factorizations = new List<List<uint>>();

            foreach (var number in numbers)
            {
                factorizations.Add(GetPrimeFactors(number));
            }

            List<uint> candidate = GetCommonFactors(factorizations[0], factorizations[1]);

            foreach (var factorization in factorizations.Skip(2))
            {
                candidate = GetCommonFactors(candidate, factorization);

                if (!candidate.Any())
                {
                    return 1;
                }
            }

            return ListProduct(candidate);
        }

        private static void GeneratePrimesUpTo(uint n)
        {
            uint startingPoint = 2;

            if (_primes.Count > 0)
            {
                startingPoint = _primes.Last() + 1;
            }

            for (uint i = startingPoint; i <= n; i++)
            {
                bool isPrime = true;
                uint maxToCheck = (uint)Math.Sqrt(i);

                foreach (uint prime in _primes)
                {
                    if (i % prime == 0)
                    {
                        isPrime = false;
                        break;
                    }

                    if (prime >= maxToCheck)
                    {
                        break;
                    }
                }

                if (isPrime)
                {
                    _primes.Add(i);
                }
            }
        }

        private static List<uint> GetPrimeFactors(uint number)
        {
            var factors = new List<uint>();

            for (int i = 0; i < _primes.Count; i++)
            {
                uint prime = _primes[i];

                while (number % prime == 0)
                {
                    factors.Add(prime);

                    number /= prime;

                    if (number == 1)
                    {
                        return factors;
                    }
                }
            }

            factors.Add(number);

            return factors;
        }

        private static List<uint> GetCommonFactors(List<uint> a, List<uint> b)
        {
            var common = new List<uint>();

            int i = 0;
            int j = 0;

            while (j < a.Count && i < b.Count)
            {
                if (a[j] == b[i])
                {
                    common.Add(a[j]);
                    j++;
                    i++;
                }
                else if (a[j] < b[i])
                {
                    j++;
                }
                else
                {
                    i++;
                }
            }

            return common;
        }

        private static uint ListProduct(List<uint> list)
        {
            uint product = 1;

            foreach (uint u in list)
            {
                product *= u;
            }

            return product;
        }
    }
}
