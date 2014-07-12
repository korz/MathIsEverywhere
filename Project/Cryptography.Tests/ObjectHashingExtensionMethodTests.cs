using Data;
using NUnit.Framework;

namespace Cryptography.Tests
{
    public class ObjectHashingExtensionMethodTests
    {
        [Test]
        public void Customer_To_MD5_Hash()
        {
            var customer = new Customer
                {
                    Id = 0,
                    FirstName = "Adelia",
                    LastName = "Kessler",
                    Address = new Address
                        {
                            Street = "16256 Reichel Plains",
                            City = "Ryanbury",
                            State = "VA",
                            Zip = "58851"
                        }
                };

            var hash1 = customer.ToMd5Hash();

            customer.FirstName = "Adeliaa";

            var hash2 = customer.ToMd5Hash();

            Assert.AreEqual("21E1C0AA0002E52DE403735EC0C19E94", hash1);
            Assert.AreEqual("356264B04B09A4DCDC009746D2185A66", hash2);
        }

        [Test]
        public void Customer_Multiple_Hash_Comparison()
        {
            var customer = new Customer
                {
                    Id = 0,
                    FirstName = "Adelia",
                    LastName = "Kessler",
                    Address = new Address
                        {
                            Street = "16256 Reichel Plains",
                            City = "Ryanbury",
                            State = "VA",
                            Zip = "58851"   
                        }
                };

            var hash1 = customer.ToMd5Hash();
            var hash2 = customer.ToMd5Hash();

            Assert.AreEqual("21E1C0AA0002E52DE403735EC0C19E94", hash1);
            Assert.AreEqual("21E1C0AA0002E52DE403735EC0C19E94", hash2);
            Assert.AreEqual(hash1, hash2);
        }

        [Test]
        public void Compare_Equal_Customers()
        {
            var customerA = new Customer
            {
                Id = 0,
                FirstName = "Adelia",
                LastName = "Kessler",
                Address = new Address
                    {
                        Street = "16256 Reichel Plains",
                        City = "Ryanbury",
                        State = "VA",
                        Zip = "58851"   
                    }
            };

            var customerB = new Customer
            {
                Id = 0,
                FirstName = "Adelia",
                LastName = "Kessler",
                Address = new Address
                    {
                        Street = "16256 Reichel Plains",
                        City = "Ryanbury",
                        State = "VA",
                        Zip = "58851"   
                    }
            };

            var hash1 = customerA.ToMd5Hash();
            var hash2 = customerB.ToMd5Hash();

            Assert.AreEqual(hash1, hash2);
            Assert.AreEqual("21E1C0AA0002E52DE403735EC0C19E94", hash1);
            Assert.AreEqual("21E1C0AA0002E52DE403735EC0C19E94", hash2);
        }

        [Test]
        public void Compare_UnEqual_Customers()
        {
            var customerA = new Customer
            {
                Id = 0,
                FirstName = "Adelia",
                LastName = "Kessler",
                Address = new Address
                    {
                        Street = "16256 Reichel Plains",
                        City = "Ryanbury",
                        State = "VA",
                        Zip = "58851"   
                    }
            };

            var customerB = new Customer
            {
                Id = 1,
                FirstName = "Melissa",
                LastName = "Labadie",
                Address = new Address
                    {
                        Street = "4751 Johan Landing",
                        City = "East Bettye",
                        State = "SD",
                        Zip = "54538"
                    }
            };

            var hash1 = customerA.ToMd5Hash();
            var hash2 = customerB.ToMd5Hash();

            Assert.AreNotEqual(hash1, hash2);
            Assert.AreEqual("21E1C0AA0002E52DE403735EC0C19E94", hash1);
            Assert.AreEqual("377D1122C74D414DE7ECC71932E94367", hash2);
        }
    }
}
