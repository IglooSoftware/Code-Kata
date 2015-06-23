using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Expression
{
    public class MathParser3
    {

        private class Node
        {
            public int Value = 0;
            public char LastOperator = ' ';
        }

        public static int compute_expression(string expr)
        {
            LinkedList<Node> parentNode = new LinkedList<Node>();
            parentNode.AddLast(new Node());
            LinkedListNode<Node> currentNode = parentNode.Last;

            Action<int> Maths = (total) =>
            {
                switch (currentNode.Value.LastOperator)
                {
                    case '+':
                        currentNode.Value.Value += total;
                        break;
                    case '-':
                        currentNode.Value.Value -= total;
                        break;
                    case ' ':
                        currentNode.Value.Value = total;
                        break;
                    default:
                        break;
                }
                currentNode.Value.LastOperator = ' ';
            };

            string runningValue = "";
            foreach (char c in expr)
            {
                if (c == '+' || c == '-')
                {
                    if (!String.IsNullOrEmpty(runningValue)) 
                        Maths(Int32.Parse(runningValue));
                    currentNode.Value.LastOperator = c;
                    runningValue = "";
                }
                else if (c == '(')
                {
                    if (!String.IsNullOrEmpty(runningValue)) 
                        Maths(Int32.Parse(runningValue));
                    parentNode.AddLast(new Node());
                    currentNode = parentNode.Last;
                    runningValue = "";
                }
                else if (c == ')')
                {
                    if (!String.IsNullOrEmpty(runningValue)) 
                        Maths(Int32.Parse(runningValue));
                    int total = currentNode.Value.Value;
                    LinkedListNode<Node> tempNode = currentNode;
                    currentNode = currentNode.Previous;
                    parentNode.Remove(tempNode);
                    Maths(total);
                    runningValue = "";
                }
                else
                {
                    runningValue += c - '0';
                }
            }
            if (!String.IsNullOrEmpty(runningValue)) Maths(Int32.Parse(runningValue));

            return currentNode.Value.Value;
        }
    }
}
