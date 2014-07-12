using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Recursion
{
    public static class MathFunctions
    {
        public static int Factorial(int n)
        {
            if (n == 0) return 1;

            return n * Factorial(n - 1);
        }

        public static int RecursiveFibonacci(int n)
        {
            if (n == 0 || n == 1) return n;

            return RecursiveFibonacci(n - 1) + 
                RecursiveFibonacci(n - 2);
        }

        public static int IterativeFibonacci(int n)
        {
            if (n == 0 || n == 1) return n;

            var numbers = new List<int> { 0, 1 };

            int counter = 2;

            while (counter <= n)
            {
                numbers.Add(numbers[counter - 2] + numbers[counter - 1]);
                counter++;
            }

            return numbers.Last();
        }

        public static BigInteger IterativeBigIntFibonacci(int n)
        {
            if (n == 0 || n == 1) return n;

            var numbers = new List<BigInteger> { 0, 1 };

            int counter = 2;

            while (counter <= n)
            {
                numbers.Add(numbers[counter - 2] + numbers[counter - 1]);
                counter++;
            }

            return numbers.Last();
        }
    }
}
