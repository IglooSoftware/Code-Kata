using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kata;

namespace Kata
{
    public class MBRunner
    {
        public static QuadTree Compare(QuadTree tree1, QuadTree tree2)
        {
            if (tree1.HasChildren && tree2.HasChildren)
            {
                return new QuadTree(Compare(tree1.Nodes[0], tree2.Nodes[0]), Compare(tree1.Nodes[1], tree2.Nodes[1]), Compare(tree1.Nodes[2], tree2.Nodes[2]), Compare(tree1.Nodes[3], tree2.Nodes[3]));
            }
            else if (tree1.HasChildren)
            {
                return ClearNonMatches(tree1, tree2.Value);
            }
            else if (tree2.HasChildren)
            {
                return ClearNonMatches(tree2, tree1.Value);
            }
            else
            {
                return new QuadTree(tree1.Value == tree2.Value ? tree1.Value : -1);
            }
        }

        private static QuadTree ClearNonMatches(QuadTree tree, int value)
        {
            if (tree.HasChildren)
            {
                return new QuadTree(ClearNonMatches(tree.Nodes[0], value), ClearNonMatches(tree.Nodes[1], value), ClearNonMatches(tree.Nodes[2], value), ClearNonMatches(tree.Nodes[3], value));
            }
            else
            {
                return new QuadTree(tree.Value == value ? value : -1);
            }
        }

        public static void Test()
        {
            QuadTree subTree1 = new QuadTree(new QuadTree(4), new QuadTree(1), new QuadTree(2), new QuadTree(2));
            QuadTree subsubTree = new QuadTree(new QuadTree(3), new QuadTree(2), new QuadTree(3), new QuadTree(1));
            QuadTree subTree2 = new QuadTree(subsubTree, new QuadTree(3), new QuadTree(4), new QuadTree(6));
            QuadTree tree1 = new QuadTree(subTree1, new QuadTree(8), new QuadTree(6), subTree2);

            QuadTree tree2 = new QuadTree(new QuadTree(2), new QuadTree(8), new QuadTree(4), new QuadTree(3));

            QuadTree compared = Compare(tree1, tree2);
        }
    }
}
