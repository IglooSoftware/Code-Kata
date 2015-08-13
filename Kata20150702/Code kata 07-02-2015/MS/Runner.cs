using Kata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata
{
    public class MSRunner
    {
        public static QuadTree Intersect(QuadTree quadOne, QuadTree quadTwo)
        {
            QuadTree quadReturn = new QuadTree();

            // Compare the values
            quadReturn.Value = quadOne.Value == quadTwo.Value ? quadOne.Value : -1;

            // Use the node parent depending on which do and do not have children. Recursively call Intersect on each node in the quadtree. 
            if (quadOne.HasChildren && !quadTwo.HasChildren)
            {
                for (int i = 0; i < 4; i++)
                {
                    quadReturn.Nodes[i] = Intersect(quadOne.Nodes[i], quadTwo);
                }
            }
            else if (quadTwo.HasChildren && !quadOne.HasChildren)
            {
                for (int i = 0; i < 4; i++)
                {
                    quadReturn.Nodes[i] = Intersect(quadOne, quadTwo.Nodes[i]);
                }
            }
            else if (quadOne.HasChildren && quadTwo.HasChildren)
            {
                for (int i = 0; i < 4; i++)
                {
                    quadReturn.Nodes[i] = Intersect(quadOne.Nodes[i], quadTwo.Nodes[i]);
                }
            }
            else
            {
                quadReturn.HasChildren = false;
            }

            return quadReturn;
        }

        public bool Equals(QuadTree quadOne, QuadTree quadTwo)
        {
            bool nodesMatch = false;

            if (quadOne.Value == quadTwo.Value && quadOne.HasChildren == quadTwo.HasChildren)
            {
                nodesMatch = true;
                for (int i = 0; i < 4 && nodesMatch && quadOne.HasChildren; i++)
                {
                    nodesMatch &= quadOne.Nodes[i].Equals(quadTwo.Nodes[i]);
                }
            }

            return nodesMatch;
        }
    }
}
