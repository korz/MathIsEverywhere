using System.Collections;
using NUnit.Framework;

namespace DataStructures.Tests
{
    public class HashTableTests
    {
        [Test]
        public void Create_And_Use()
        {
            var hashTable = new Hashtable();

            hashTable.Add("John Smith", "521-1234");
            hashTable.Add("Lisa Smith", "521-8976");
            hashTable.Add("Sandra Dee", "521-9655");

            var sandrasNumber = hashTable["Sandra Dee"];

            Assert.AreEqual(3, hashTable.Count);
            Assert.AreEqual("521-9655", sandrasNumber);
        }
    }
}
