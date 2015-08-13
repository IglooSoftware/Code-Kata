using ParseTime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DigitalClockParse {
	class Program {

        static void Main(string[] args)
        {
            int iterations = 10000;
            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < iterations; i++)
                MS.Runner.GetTime(@"time.txt"); // 2150
            sw.Stop();
            Console.WriteLine("MS : " + sw.ElapsedTicks + " ticks\n");
            sw.Reset();

            sw.Start();
            for (int i = 0; i < iterations; i++)
                KM.Runner.GetTime(@"time.txt");
            sw.Stop();
            Console.WriteLine("KM : " + sw.ElapsedTicks + " ticks\n");
            sw.Reset();

            sw.Start();
            for (int i = 0; i < iterations; i++)
                SJ.Runner.GetTime(@"time.txt");
            sw.Stop();
            Console.WriteLine("SJ : " + sw.ElapsedTicks + " ticks\n");
            sw.Reset();

            sw.Start();
            for (int i = 0; i < iterations; i++)
                MB.Runner.GetTime(@"time.txt");
            sw.Stop();
            Console.WriteLine("MB : " + sw.ElapsedTicks + " ticks\n");

            Console.ReadKey();
        }
    }
}
