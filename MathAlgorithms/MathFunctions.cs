using System;
using System.Collections.Generic;
using System.Linq;

namespace MathAlgorithms
{
    public sealed class MathFunctions
    {
        private MathFunctions() { }
        private static readonly MathFunctions _Instance = new MathFunctions();
        public static MathFunctions Instance => _Instance;

        public long Exponential(long digit, long power)
        {
            if (digit == 0)
                return 0;
            if (digit == 1 || power == 0)
                return 1;

            if (power == 1)
                return digit;

            return digit * Exponential(digit, power - 1);
        }

        public long Factorial(long number)
        {
            if (number == 0)
                return 0;
            if (number == 1)
                return 1;

            return number * Factorial(number - 1);
        }

        public bool IsPrime(long number)
        {
            if (number%2 == 0)
                return false;

            for (long i = 3; i < number; i++)
            {
                if (number%i == 0)
                    return false;
            }
            return true;
        }
    }
}
