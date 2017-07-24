using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var expressions = new List<string>();
            var pattern = @"(\d+)\s*([-+*/])\s*(\d+)"; //regular expression
            Math math = new Math(); //initialize Math Class
            
            while (true)
            {
                Console.Write("Perform a simple calculation (e.g 25*2 or 15-3): ");
                expressions.Add(Console.ReadLine());

                if (!String.IsNullOrWhiteSpace(expressions[0]))
                {
                    foreach (var expression in expressions)
                    {
                        var boolean = Regex.Matches(expression, pattern);
                        if (boolean.Count == 0)
                            goto Invalid;
                        foreach (Match m in Regex.Matches(expression, pattern))
                        {
                            var num1 = Int64.Parse(m.Groups[1].Value);
                            var num2 = Int64.Parse(m.Groups[3].Value);
                            switch (m.Groups[2].Value)
                            {
                                case "+":
                                    Console.WriteLine("{0} + {1} = {2}", num1, num2, math.Add(num1, num2));
                                    break;
                                case "-":
                                    Console.WriteLine("{0} + {1} = {2}", num1, num2, math.Sub(num1, num2));
                                    break;
                                case "*":
                                    Console.WriteLine("{0} + {1} = {2}", num1, num2, math.Multi(num1, num2));
                                    break;
                                case "/":
                                    Console.WriteLine("{0} + {1} = {2}", num1, num2,math.Div(num1, num2));
                                    break;
                            }
                        }
                    }
                    expressions.Clear();
                    continue;
                }

                Invalid: 
                expressions.Clear();
                Console.WriteLine("Invalid Equation");
            }
        }
    }
}
