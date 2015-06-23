using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Expression
{
    public class MathParser2
    {
        public static string EvaluateExpression(string expression, string part = null)
        {
            string result = expression;
            result = result.Replace(" ", "");

            if (part == null)
            {
                int startindex = result.LastIndexOf('(');
                if (startindex != -1)
                {
                    int closingIndex = result.IndexOf(')', startindex);
                    string bracePart = result.Substring(startindex, closingIndex - startindex + 1);
                    return EvaluateExpression(result, bracePart);
                }
            }
            else
            {
                string replacement = Calculate(part);
                return EvaluateExpression(result.Replace(part, replacement));
            }

            return Calculate(result);
        }

        static string Calculate(string part)
        {
            int i = 0;
            int indexOfOperator = -1;
            bool add = false;
            string tempStr = part;
            int total = 0;

            while (tempStr.Contains('+') || tempStr.Contains('-'))
            {
                add = false;
                for (int o = 0; o < tempStr.Length; o++)
                {
                    if (tempStr[o] == '-')
                    {
                        if (o != 0 && tempStr[o - 1] != '(')
                        {
                            indexOfOperator = o;
                            break;
                        }
                        else if (o != 0 && tempStr[o - 1] == '(' && tempStr.IndexOf('-', o + 1) == -1 && tempStr.IndexOf('+', o + 1) == -1)
                        {
                            return total.ToString();
                        }
                        else if (o == 0 && tempStr.IndexOf('-', o + 1) == -1 && tempStr.IndexOf('+', o + 1) == -1)
                        {
                            return total.ToString();
                        }
                    }
                    else if (tempStr[o] == '+')
                    {
                        add = true;
                        break;
                    }
                }

                if (add)
                {
                    indexOfOperator = tempStr.IndexOf('+');
                }

                i = indexOfOperator - 1;

                while (i > 0 && (Char.IsDigit(tempStr[i - 1]) || tempStr[i - 1] == '-'))
                {
                    i--;
                }

                string left = tempStr.Substring(i, indexOfOperator - i);

                i = indexOfOperator + 1;
                while (i < tempStr.Length - 1 && Char.IsDigit(tempStr[i + 1]))
                {
                    i++;
                }

                string right = tempStr.Substring(indexOfOperator + 1, i - indexOfOperator);

                if (add)
                {
                    total = Convert.ToInt32(left) + Convert.ToInt32(right);
                    tempStr = tempStr.Replace(left + "+" + right, total.ToString());
                }
                else
                {
                    total = Convert.ToInt32(left) - Convert.ToInt32(right);
                    tempStr = tempStr.Replace(left + "-" + right, total.ToString());
                }
            }

            return total.ToString();
        }
    }
}
