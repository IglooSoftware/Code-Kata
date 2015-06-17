using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Kata20150616
{
    class Program
    {
        private static List<Tuple<string, TimeSpan, int>> _results = new List<Tuple<string, TimeSpan, int>>();

        static void Main(string[] args)
        {
            Dictionary<uint[], uint> collections = CreateData();
            
            RunTest(collections, "Jocelyn", Jocelyn.GCD);
            RunTest(collections, "Joe", Joe.GCD);
            RunTest(collections, "Matt", Matt.GCD);
            RunTest(collections, "Mike", Mike.GCD);
            RunTest(collections, "Dave", Dave.GCD);
            RunTest(collections, "Dave GCD2NoStorage", Dave.GCD2NoStorage);
            //RunTest(collections, "Dave GCD3Task", Dave.GCD3Task);
            RunTest(collections, "Kiel", Kiel.GCD);
            RunTest(collections, "Scott", Scott.GCD);
            //RunTest(collections, "Sean", Sean.GCD);

            Console.WriteLine();
            Console.WriteLine("*****************************");
            Console.WriteLine("*******RANKINGS**************");
            Console.WriteLine("*****************************");
            Console.WriteLine();

            var rankings = _results.OrderBy(result => result.Item2);

            foreach(var entry in rankings)
            {
                if (entry.Item3 == collections.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                Console.WriteLine(entry.Item1.PadRight(25) + "PASSED: " + entry.Item3.ToString().PadLeft(4) + " of " + collections.Count + "   DURATION: " + entry.Item2.ToString());
                Console.ResetColor();
            }

            Console.Read();
        }

        private static void RunTest(Dictionary<uint[], uint> collections, string name, Func<uint[], uint> getGcd)
        {
            int passed = 0;
            Stopwatch timer = new Stopwatch();
            timer.Start();


            foreach (KeyValuePair<uint[], uint> item in collections)
            {
                try
                {
                    if (getGcd(item.Key) == item.Value)
                    {
                        passed++;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(name + " INPUTS: [" + string.Join(",", item.Key) + "] GCD: " + item.Value + " ERROR: " + ex.ToString());
                    Console.ResetColor();
                    break;
                }
            }
            

            timer.Stop();

            if (passed == collections.Count)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.WriteLine(name.PadRight(25) + "PASSED: " + passed.ToString().PadLeft(4) + " of " + collections.Count + "   DURATION: " + timer.Elapsed.ToString());
            Console.ResetColor();

            _results.Add(new Tuple<string, TimeSpan, int>(name, timer.Elapsed, passed));
        }

        private static Dictionary<uint[], uint> CreateData()
        {
            Dictionary<uint[], uint> collections = new Dictionary<uint[], uint>();
            Random random = new Random();
            var divisors = new int[500];

            for (int i = 0; i < divisors.Length; i++ )
            {
                divisors[i] = random.Next(1, 46340);
            }

                for (int j = 0; j < divisors.Length; j++)
                {
                    int divisor = divisors[j];
                    int lowest = 0;
                    uint gcd = (uint)divisor;
                    int entries = random.Next(2, 10);
                    uint[] collection = new uint[entries];

                    for (int i = 0; i < entries; i++)
                    {
                        int multiple = (random.Next(1, divisor - 1) * divisor);
                        collection[i] = (uint)multiple;

                        if (lowest == 0 || multiple < lowest)
                        {
                            lowest = multiple;
                        }
                    }

                    collections.Add(collection, Jocelyn.GCD(collection));
                }

            return collections;
        }
    }
}
