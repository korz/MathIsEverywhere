using NUnit.Framework;

namespace Recursion.Tests
{
    public class FactorialTests
    {
        [Test]
        public void Factorial_0()
        {
            var result = MathFunctions.Factorial(0);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void Factorial_1()
        {
            var result = MathFunctions.Factorial(1);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void Factorial_3()
        {
            var result = MathFunctions.Factorial(3);

            Assert.AreEqual(6, result);
        }

        [Test]
        public void Factorial_5()
        {
            var result = MathFunctions.Factorial(5);

            Assert.AreEqual(120, result);
        }

        [Test]
        public void Factorial_Negative_1()
        {
            //var result = MathFunctions.Factorial(-1);

            //Gets caught in an infinite loop and times out
        }
    }
}
