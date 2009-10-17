using System;
using System.Collections.Generic;
using Utilities.Extendions;

namespace Calc.Code
{
    public class Calculator
    {
        public static int Add(params string[] arguments)
        {
            return Calculate(arguments, (a, b) => a + b, 0);
        }

        public static int Multiply(params string[] arguments)
        {
            return Calculate(arguments, (a, b) => a*b, 1);
        }

        private static int Calculate(IEnumerable<string> argumentList, Func<int, int, int> operation, int neutralValue)
        {
            var result = neutralValue;
            argumentList = Expand(argumentList);
            argumentList.ForEach(arg => result = operation(result, GetValue(arg)));
            return result;
        }

        private static IEnumerable<string> Expand(IEnumerable<string> arguments)
        {
            if (arguments.IsNull()) throw new ArgumentNullException();

            var expanded = new List<string>();
            arguments.ForEach(argument => expanded.AddRange(argument.Split(',')));
            return expanded;
        }

        private static int GetValue(string argument)
        {
            try
            {
                return int.Parse(argument);
            }
            catch
            {
                throw new ArgumentException(string.Format("Couldn't convert '{0}' to a number", argument));
            }
        }
    }
}