using NUnit.Framework;

namespace Recursion.Tests
{
    public class FibonacciTests
    {
        [Test, MaxTime(20000)]
        public void Recursive()
        {
            var result = MathFunctions.RecursiveFibonacci(45);

            Assert.AreEqual(1134903170, result);
        }

        [Test, MaxTime(100)]
        public void Iterative()
        {
            var result = MathFunctions.IterativeFibonacci(45);

            Assert.AreEqual(1134903170, result);
        }

        [Test, MaxTime(100)]
        public void Iterative_Max()
        {
            var result = MathFunctions.IterativeBigIntFibonacci(1000);

            Assert.AreEqual("43466557686937456435688527675040625802564660517371780402481729089536555417949051890403879840079255169295922593080322634775209689623239873322471161642996440906533187938298969649928516003704476137795166849228875", result.ToString());
        }
    }
}
