using Data;
using NUnit.Framework;

namespace Tests
{
    public class CustomerEqualityTests
    {
        [Test]
        public void Customers_Are_Same()
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

            Assert.IsTrue(customerA.Equals(customerB));
        }

        [Test]
        public void Customers_Are_Same_Reference()
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

            var customerB = customerA;

            Assert.IsTrue(customerA.Equals(customerB));
        }

        [Test]
        public void Customers_Are_Same_But_With_Different_Id()
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
                Id = 3,
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

            Assert.IsFalse(customerA.Equals(customerB));
        }

        [Test]
        public void Customers_Are_Different()
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

            Assert.IsFalse(customerA.Equals(customerB));
        }
    }
}
