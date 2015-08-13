using Kata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata
{
    public class SJRunner
    {
        public static QuadTree compare(QuadTree qt1, QuadTree qt2)
        {
            if (qt1.HasChildren && qt2.HasChildren)
            {
                for (int i = 0; i < qt1.Nodes.Length; i++)
                {
                    qt1.Nodes[i] = compare(qt1.Nodes[i], qt2.Nodes[i]);
                }
            }
            else if (qt1.HasChildren && !qt2.HasChildren)
            {
                for (int i = 0; i < qt1.Nodes.Length; i++)
                {
                    qt1.Nodes[i] = compare(qt1.Nodes[i], qt2);
                }
            }
            else if (!qt1.HasChildren && qt2.HasChildren)
            {
                for (int i = 0; i < qt1.Nodes.Length; i++)
                {
                    qt1.Nodes[i] = compare(qt1, qt2.Nodes[i]);
                }
            }
            else
            {
                if (qt1.Value != qt2.Value)
                {
                    qt1.Value = -1;
                }
            }

            return qt1;
        }
    }
}
