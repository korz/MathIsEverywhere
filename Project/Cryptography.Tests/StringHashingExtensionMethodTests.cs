using NUnit.Framework;

namespace Cryptography.Tests
{
    public class StringHashingExtensionMethodTests
    {
        [Test]
        public void Hello_World_To_MD5_Hash()
        {
            const string text = "Hello World!";

            var hash = text.ToMd5Hash();

            Assert.AreEqual("ED076287532E86365E841E92BFC50D8C", hash);
        }

        [Test]
        public void Hello_World_Without_Exclaimation_Point()
        {
            const string text = "Hello World";

            var hash = text.ToMd5Hash();

            Assert.AreEqual("B10A8DB164E0754105B7A99BE72E3FE5", hash);
        }

        [Test]
        public void Hello_World_Multiple_Hash_Comparison()
        {
            const string text = "Hello World!";

            var hash1 = text.ToMd5Hash();
            var hash2 = text.ToMd5Hash();

            Assert.AreEqual("ED076287532E86365E841E92BFC50D8C", hash1);
            Assert.AreEqual("ED076287532E86365E841E92BFC50D8C", hash2);
            Assert.AreEqual(hash1, hash2);
        }
    }
}
