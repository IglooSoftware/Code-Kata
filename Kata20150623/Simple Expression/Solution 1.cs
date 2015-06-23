using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple_Expression
{
    public class MathParser
    {
        public static int Evaluate(string s)
        {
            List<Token> tokens = Tokenize(s);
            ExpressionTree tree = ExpressionTree.BuildFromTokens(tokens);
            Token finalToken = tree.Evaluate();

            return finalToken.NumericalValue;
        }

        private static List<Token> Tokenize(string s)
        {
            List<Token> tokens = new List<Token>();

            char[] operators = new char[] { '(', ')', '+', '-' };

            var charArray = s.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                char c = charArray[i];

                TokenType type;
                int tokenValue = 0;

                if (c == '(')
                {
                    type = TokenType.OpenBracket;
                }
                else if (c == ')')
                {
                    type = TokenType.CloseBracket;
                }
                else if (c == '+')
                {
                    type = TokenType.PlusSign;
                }
                else if (c == '-')
                {
                    type = TokenType.MinusSign;
                }
                else
                {
                    type = TokenType.Number;

                    StringBuilder number = new StringBuilder(c.ToString());

                    while ((i + 1) < charArray.Length && !operators.Contains(charArray[i + 1]))
                    {
                        number.Append(charArray[++i].ToString());
                    }

                    tokenValue = Int32.Parse(number.ToString());
                }

                tokens.Add(new Token { Type = type, NumericalValue = tokenValue });
            }

            return tokens;
        }
    }

    public class ExpressionTree
    {
        public List<ExpressionTree> Children { get; set; }
        public Token Value { get; set; }

        public ExpressionTree()
        {
            Children = new List<ExpressionTree>();
        }

        public Token Evaluate()
        {
            if (Children.Count == 0)
            {
                return Value;
            }

            int value = Children[0].Evaluate().NumericalValue;

            for (int i = 2; i < Children.Count; i += 2)
            {
                int nextVal = Children[i].Evaluate().NumericalValue;
                Token op = Children[i - 1].Value;

                if (op.Type == TokenType.PlusSign)
                {
                    value += nextVal;
                }
                else
                {
                    value -= nextVal;
                }
            }

            return new Token { Type = TokenType.Number, NumericalValue = value };
        }

        public static ExpressionTree BuildFromTokens(List<Token> tokens)
        {
            ExpressionTree tree = new ExpressionTree();

            if (!tokens.Any(t => t.Type == TokenType.OpenBracket))
            {
                // if there aren't any brackets, just add everything one after another
                foreach (Token token in tokens)
                {
                    tree.Children.Add(new ExpressionTree { Value = token });
                }
            }
            else
            {
                for (int i = 0; i < tokens.Count; i++)
                {
                    Token token = tokens[i];
                    if (token.Type == TokenType.MinusSign || token.Type == TokenType.PlusSign || token.Type == TokenType.Number)
                    {
                        tree.Children.Add(new ExpressionTree { Value = token });
                    }
                    else if (token.Type == TokenType.OpenBracket)
                    {
                        // after finding a bracket, make a subtree out of everything until the closing bracket
                        // recursion handles nested braces
                        int depth = 1;
                        int endSub = i + 1;

                        while (depth > 0)
                        {
                            token = tokens[endSub++];

                            if (token.Type == TokenType.OpenBracket)
                            {
                                depth++;
                            }
                            else if (token.Type == TokenType.CloseBracket)
                            {
                                depth--;
                            }
                        }

                        ExpressionTree subTree = BuildFromTokens(tokens.Skip(i + 1).Take(endSub - (i + 2)).ToList());
                        tree.Children.Add(subTree);
                        i = endSub - 1;
                    }

                }
            }

            return tree;
        }
    }

    public class Token
    {
        public TokenType Type { get; set; }

        public int NumericalValue { get; set; }
    }

    public enum TokenType
    {
        OpenBracket,
        CloseBracket,
        Number,
        PlusSign,
        MinusSign
    }
}
