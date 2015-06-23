using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Simple_Expression {
	class Program {

		/*
			Write a simple parser to parse a formula and calculate the result. 
			Given a string containing only integer numbers, brackets, plus and minus signs, 
			calculate and print the numeric answer. Assume that the formula will always 
			follow correct syntax
			Example input:
			(2+2)-(3-(6-5))-4
			Example output:
			-2
		*/

		public static DataTable dt = new DataTable();

		public static int compute_expression(string expr) {
			return (int)dt.Compute(expr, null);
		}

		static void Main(string[] args) {
            Console.WriteLine(compute_expression("(2+2)-(3-(6-5))-4"));               // Given

            Console.WriteLine(MathParser.Evaluate("(2+2)-(3-(6-5))-4"));              // MB
            Console.WriteLine(MathParser2.EvaluateExpression("(2+2)-(3-(6-5))-4"));   // SJ
            Console.WriteLine(MathParser3.compute_expression("(2+2)-(3-(6-5))-4"));   // MS

			Console.ReadKey();
		}
	}
}
