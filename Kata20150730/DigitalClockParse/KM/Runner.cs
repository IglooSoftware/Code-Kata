using ParseTime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClockParse.KM
{
    class Runner
    {
        public static void GetTime(string path)
        {
            var lines = File.ReadAllLines(path);
            var chars = new List<TimeCharResolver>();

            for (var i = 0; i < lines[0].Length; i += 3)
            {
                var slice = lines[0].Substring(i, 3);
                chars.Add(new TimeCharResolver(slice));
            }

            for (var i = 1; i < 3; i++)
            {
                for (var j = 0; j < chars.Count; j++)
                {
                    var slice = lines[i].Substring(j * 3, 3);
                    chars[j].AddSlice(slice);
                }
            }

            var str = String.Concat(chars.Select(o => o.GetTimeChar()));
            //Console.WriteLine(str);
        }
    }
}
