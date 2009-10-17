using System;
using System.Collections.Generic;
using Utilities.Extendions;

namespace Calc.Code
{
    public class Calculator
    {
        public static int Add(string arguments)
        {
            return arguments.IsNull()
                       ? 0
                       : CalculateSum(arguments.Split(','));
        }

        public static int Add(params string[] arguments)
        {
            return CalculateSum(arguments);
        }

        private static int CalculateSum(IEnumerable<string> arguments)
        {
            return Calculate(arguments, (a, b) => a + b, 0);
        }

        public static int Multiply(string arguments)
        {
            return arguments.IsNull()
                       ? 1
                       : Calculate(arguments.Split(','), (a, b) => a * b, 1);
        }

        private static int Calculate(IEnumerable<string> argumentList, Func<int, int, int> operation, int neutralValue)
        {
            var result = neutralValue;
            argumentList.ForEach(arg => result = operation(result, GetValue(arg, neutralValue)));
            return result;
        }

        private static int GetValue(string argument, int neutralValue)
        {
            try
            {
                return int.Parse(argument);
            }
            catch
            {
                return neutralValue;
            }
        }
    }
}