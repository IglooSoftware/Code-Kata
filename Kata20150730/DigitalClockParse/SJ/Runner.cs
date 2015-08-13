using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClockParse.SJ
{
    public class Runner
    {
        public static void GetTime(string path)
        {
            List<char[,]> numbers = BuildSevenSegsFromFile(path);
            OutputTime(numbers);
        }

        static List<char[,]> BuildSevenSegsFromFile(string location)
        {
            List<char[,]> numbers = new List<char[,]>();
            using (StreamReader r = new StreamReader(location))
            {
                string line = r.ReadLine();

                int numNumbers = line.Length / 3;

                for (int i = 0; i < numNumbers; i++)
                {
                    numbers.Add(new char[3, 3]);
                }

                for (int i = 0; i < 3; i++)
                {
                    for (int o = 0; o < numNumbers; o++)
                    {
                        for (int p = 0; p < 3; p++)
                        {
                            numbers[o][i, p] = line[o * 3 + p];
                        }
                    }
                    line = r.ReadLine();
                }
            }

            return numbers;
        }

        static void OutputTime(List<char[,]> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                //Console.Write(SevenSegUtil.ConvertSevenSeg(numbers[i]));
                if (i == 0 && numbers.Count == 3)
                {
                    //Console.Write(':');
                }
                else if (i == 1 && numbers.Count == 4)
                {
                    //Console.Write(':');
                }
            }
            //Console.Write('\n');
        }
    }
}
