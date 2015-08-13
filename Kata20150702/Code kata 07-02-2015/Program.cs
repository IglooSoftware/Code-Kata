using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Kata;

namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            QuadTree qt1 = new QuadTree();
            qt1.Nodes[0] = new QuadTree(new QuadTree(5), new QuadTree(7), new QuadTree(2), new QuadTree(4));
            qt1.Nodes[1] = new QuadTree(5);
            qt1.Nodes[2] = new QuadTree(3);
            qt1.Nodes[3] = new QuadTree(new QuadTree(6), new QuadTree(new QuadTree(5), new QuadTree(6), new QuadTree(12), new QuadTree(9)), new QuadTree(0), new QuadTree(3));

            QuadTree qt2 = new QuadTree();
            qt2.Nodes[0] = new QuadTree(new QuadTree(6), new QuadTree(7), new QuadTree(4), new QuadTree(4));
            qt2.Nodes[1] = new QuadTree(7);
            qt2.Nodes[2] = new QuadTree(4);
            qt2.Nodes[3] = new QuadTree(6);

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                QuadTree qt3 = SJRunner.compare(qt1, qt2);
            }
            sw.Stop();
            Console.WriteLine("SJ: {0} seconds", (double)sw.ElapsedMilliseconds / 1000);

            sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                QuadTree qt3 = MBRunner.Compare(qt1, qt2);
            }
            sw.Stop();
            Console.WriteLine("MB: {0} seconds", (double)sw.ElapsedMilliseconds / 1000);

            sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                QuadTree qt3 = MSRunner.Intersect(qt1, qt2);
            }
            sw.Stop();
            Console.WriteLine("MS: {0} seconds", (double)sw.ElapsedMilliseconds / 1000);
            Console.ReadKey();
        }

    }
}
