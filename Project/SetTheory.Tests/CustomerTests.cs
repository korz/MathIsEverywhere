using System.Collections.Generic;
using System.Linq;
using Data;
using NUnit.Framework;

namespace SetTheory.Tests
{
    public class CustomerTests
    {
        [Test]
        public void Is_Subset()
        {
            var a = new List<Customer>
                {
                    new Customer { Id = 0, FirstName = "Adelia", LastName = "Kessler", Address = new Address{ Street = "16256 Reichel Plains", City = "Ryanbury", State = "VA", Zip = "58851" }},
                    new Customer { Id = 1, FirstName = "Melissa", LastName = "Labadie", Address = new Address{ Street = "4751 Johan Landing", City = "East Bettye", State = "SD", Zip = "54538" }},
                    new Customer { Id = 2, FirstName = "Gerard", LastName = "Gerhold", Address = new Address{ Street = "242 Friesen Locks", City = "Jaylenhaven", State = "PR", Zip = "86606" }},
                };

            var b = new List<Customer>
                {
                    new Customer { Id = 0, FirstName = "Adelia", LastName = "Kessler", Address = new Address{ Street = "16256 Reichel Plains", City = "Ryanbury", State = "VA", Zip = "58851" }},
                    new Customer { Id = 1, FirstName = "Melissa", LastName = "Labadie", Address = new Address{ Street = "4751 Johan Landing", City = "East Bettye", State = "SD", Zip = "54538" }},
                    new Customer { Id = 2, FirstName = "Gerard", LastName = "Gerhold", Address = new Address{ Street = "242 Friesen Locks", City = "Jaylenhaven", State = "PR", Zip = "86606" }},
                    new Customer { Id = 3, FirstName = "Clemens", LastName = "Kassulke", Address = new Address{ Street = "0584 Leffler Garden", City = "East Cathy", State = "KY", Zip = "05828" }},
                    new Customer { Id = 4, FirstName = "Cloyd", LastName = "Heaney", Address = new Address{ Street = "2486 Graham Junction", City = "New Pietro", State = "AE", Zip = "66483" }},
                    new Customer { Id = 5, FirstName = "Magdalena", LastName = "Lynch", Address = new Address{ Street = "17177 Parisian Lake", City = "Zaneton", State = "OK", Zip = "21861" }}
                };

           var result = !a.Except(b).Any();

            Assert.IsTrue(result);
        }

        [Test]
        public void Is_Not_Subset()
        {
            var a = new List<Customer>
                {
                    new Customer { Id = 0, FirstName = "Adelia", LastName = "Kessler", Address = new Address{ Street = "16256 Reichel Plains", City = "Ryanbury", State = "VA", Zip = "58851" }},
                    new Customer { Id = 1, FirstName = "Melissa", LastName = "Labadie", Address = new Address{ Street = "4751 Johan Landing", City = "East Bettye", State = "SD", Zip = "54538" }},
                    new Customer { Id = 6, FirstName = "Zoila", LastName = "Sanford", Address = new Address{ Street = "3832 Hilll Vista", City = "Kaleymouth", State = "NV", Zip = "66815" }}
                };

            var b = new List<Customer>
                {
                    new Customer { Id = 0, FirstName = "Adelia", LastName = "Kessler", Address = new Address{ Street = "16256 Reichel Plains", City = "Ryanbury", State = "VA", Zip = "58851" }},
                    new Customer { Id = 1, FirstName = "Melissa", LastName = "Labadie", Address = new Address{ Street = "4751 Johan Landing", City = "East Bettye", State = "SD", Zip = "54538" }},
                    new Customer { Id = 2, FirstName = "Gerard", LastName = "Gerhold", Address = new Address{ Street = "242 Friesen Locks", City = "Jaylenhaven", State = "PR", Zip = "86606" }},
                    new Customer { Id = 3, FirstName = "Clemens", LastName = "Kassulke", Address = new Address{ Street = "0584 Leffler Garden", City = "East Cathy", State = "KY", Zip = "05828" }},
                    new Customer { Id = 4, FirstName = "Cloyd", LastName = "Heaney", Address = new Address{ Street = "2486 Graham Junction", City = "New Pietro", State = "AE", Zip = "66483" }},
                    new Customer { Id = 5, FirstName = "Magdalena", LastName = "Lynch", Address = new Address{ Street = "17177 Parisian Lake", City = "Zaneton", State = "OK", Zip = "21861" }}
                };

            var result = !a.Except(b).Any();

            Assert.IsFalse(result);
        }

        [Test]
        public void Sets_Are_Equal()
        {
            var a = new List<Customer>
                {
                    new Customer { Id = 0, FirstName = "Adelia", LastName = "Kessler", Address = new Address{ Street = "16256 Reichel Plains", City = "Ryanbury", State = "VA", Zip = "58851" }},
                    new Customer { Id = 1, FirstName = "Melissa", LastName = "Labadie", Address = new Address{ Street = "4751 Johan Landing", City = "East Bettye", State = "SD", Zip = "54538" }},
                    new Customer { Id = 2, FirstName = "Gerard", LastName = "Gerhold", Address = new Address{ Street = "242 Friesen Locks", City = "Jaylenhaven", State = "PR", Zip = "86606" }},
                };

            var b = new List<Customer>
                {
                    new Customer { Id = 0, FirstName = "Adelia", LastName = "Kessler", Address = new Address{ Street = "16256 Reichel Plains", City = "Ryanbury", State = "VA", Zip = "58851" }},
                    new Customer { Id = 1, FirstName = "Melissa", LastName = "Labadie", Address = new Address{ Street = "4751 Johan Landing", City = "East Bettye", State = "SD", Zip = "54538" }},
                    new Customer { Id = 2, FirstName = "Gerard", LastName = "Gerhold", Address = new Address{ Street = "242 Friesen Locks", City = "Jaylenhaven", State = "PR", Zip = "86606" }},
                };

            var result = a.SequenceEqual(b);

            Assert.IsTrue(result);
        }

        [Test]
        public void Sets_Are_Not_Equal()
        {
            var a = new List<Customer>
                {
                    new Customer { Id = 0, FirstName = "Adelia", LastName = "Kessler", Address = new Address{ Street = "16256 Reichel Plains", City = "Ryanbury", State = "VA", Zip = "58851" }},
                    new Customer { Id = 1, FirstName = "Melissa", LastName = "Labadie", Address = new Address{ Street = "4751 Johan Landing", City = "East Bettye", State = "SD", Zip = "54538" }},
                    new Customer { Id = 2, FirstName = "Gerard", LastName = "Gerhold", Address = new Address{ Street = "242 Friesen Locks", City = "Jaylenhaven", State = "PR", Zip = "86606" }},
                };

            var b = new List<Customer>
                {
                    new Customer { Id = 0, FirstName = "Adelia", LastName = "Kessler", Address = new Address{ Street = "16256 Reichel Plains", City = "Ryanbury", State = "VA", Zip = "58851" }},
                    new Customer { Id = 1, FirstName = "Melissa", LastName = "Labadie", Address = new Address{ Street = "4751 Johan Landing", City = "East Bettye", State = "SD", Zip = "54538" }},
                    new Customer { Id = 6, FirstName = "Zoila", LastName = "Sanford", Address = new Address{ Street = "3832 Hilll Vista", City = "Kaleymouth", State = "NV", Zip = "66815" }}
                };

            var result = a.SequenceEqual(b);

            Assert.IsFalse(result);
        }

        [Test]
        public void Union()
        {
            var a = new List<Customer>
                {
                    new Customer { Id = 0, FirstName = "Adelia", LastName = "Kessler", Address = new Address { Street = "16256 Reichel Plains", City = "Ryanbury", State = "VA", Zip = "58851" }},
                    new Customer { Id = 1, FirstName = "Melissa", LastName = "Labadie", Address = new Address { Street = "4751 Johan Landing", City = "East Bettye", State = "SD", Zip = "54538" }},
                    new Customer { Id = 2, FirstName = "Gerard", LastName = "Gerhold", Address = new Address { Street = "242 Friesen Locks", City = "Jaylenhaven", State = "PR", Zip = "86606" }},
                };

            var b = new List<Customer>
                {
                    new Customer { Id = 2, FirstName = "Gerard", LastName = "Gerhold", Address = new Address { Street = "242 Friesen Locks", City = "Jaylenhaven", State = "PR", Zip = "86606" }},
                    new Customer { Id = 3, FirstName = "Clemens", LastName = "Kassulke", Address = new Address { Street = "0584 Leffler Garden", City = "East Cathy", State = "KY", Zip = "05828" }},
                    new Customer { Id = 4, FirstName = "Cloyd", LastName = "Heaney", Address = new Address { Street = "2486 Graham Junction", City = "New Pietro", State = "AE", Zip = "66483" }},
                };

            var results = a.Union(b).ToList();

            Assert.AreEqual(5, results.Count());
            Assert.AreEqual(0, results[0].Id);
            Assert.AreEqual(1, results[1].Id);
            Assert.AreEqual(2, results[2].Id);
            Assert.AreEqual(3, results[3].Id);
            Assert.AreEqual(4, results[4].Id);
        }

        [Test]
        public void Intersection()
        {
            var a = new List<Customer>
                {
                    new Customer { Id = 0, FirstName = "Adelia", LastName = "Kessler", Address = new Address { Street = "16256 Reichel Plains", City = "Ryanbury", State = "VA", Zip = "58851" }},
                    new Customer { Id = 1, FirstName = "Melissa", LastName = "Labadie", Address = new Address { Street = "4751 Johan Landing", City = "East Bettye", State = "SD", Zip = "54538" }},
                    new Customer { Id = 2, FirstName = "Gerard", LastName = "Gerhold", Address = new Address { Street = "242 Friesen Locks", City = "Jaylenhaven", State = "PR", Zip = "86606" }},
                };

            var b = new List<Customer>
                {
                    new Customer { Id = 0, FirstName = "Adelia", LastName = "Kessler", Address = new Address { Street = "16256 Reichel Plains", City = "Ryanbury", State = "VA", Zip = "58851" }},
                    new Customer { Id = 1, FirstName = "Melissa", LastName = "Labadie", Address = new Address { Street = "4751 Johan Landing", City = "East Bettye", State = "SD", Zip = "54538" }},
                    new Customer { Id = 2, FirstName = "Gerard", LastName = "Gerhold", Address = new Address { Street = "242 Friesen Locks", City = "Jaylenhaven", State = "PR", Zip = "86606" }},
                    new Customer { Id = 3, FirstName = "Clemens", LastName = "Kassulke", Address = new Address { Street = "0584 Leffler Garden", City = "East Cathy", State = "KY", Zip = "05828" }},
                    new Customer { Id = 4, FirstName = "Cloyd", LastName = "Heaney", Address = new Address { Street = "2486 Graham Junction", City = "New Pietro", State = "AE", Zip = "66483" }},
                };

            var results = a.Intersect(b).ToList();

            Assert.AreEqual(3, results.Count());
            Assert.AreEqual(0, results[0].Id);
            Assert.AreEqual(1, results[1].Id);
            Assert.AreEqual(2, results[2].Id);
        }

        [Test]
        public void Difference()
        {
            var a = new List<Customer>
                {
                    new Customer { Id = 0, FirstName = "Adelia", LastName = "Kessler", Address = new Address { Street = "16256 Reichel Plains", City = "Ryanbury", State = "VA", Zip = "58851" }},
                    new Customer { Id = 1, FirstName = "Melissa", LastName = "Labadie", Address = new Address { Street = "4751 Johan Landing", City = "East Bettye", State = "SD", Zip = "54538" }},
                    new Customer { Id = 2, FirstName = "Gerard", LastName = "Gerhold", Address = new Address { Street = "242 Friesen Locks", City = "Jaylenhaven", State = "PR", Zip = "86606" }},
                };

            var b = new List<Customer>
                {
                    new Customer { Id = 0, FirstName = "Adelia", LastName = "Kessler", Address = new Address { Street = "16256 Reichel Plains", City = "Ryanbury", State = "VA", Zip = "58851" }},
                    new Customer { Id = 1, FirstName = "Melissa", LastName = "Labadie", Address = new Address { Street = "4751 Johan Landing", City = "East Bettye", State = "SD", Zip = "54538" }},
                    new Customer { Id = 2, FirstName = "Gerard", LastName = "Gerhold", Address = new Address { Street = "242 Friesen Locks", City = "Jaylenhaven", State = "PR", Zip = "86606" }},
                    new Customer { Id = 3, FirstName = "Clemens", LastName = "Kassulke", Address = new Address { Street = "0584 Leffler Garden", City = "East Cathy", State = "KY", Zip = "05828" }},
                    new Customer { Id = 4, FirstName = "Cloyd", LastName = "Heaney", Address = new Address { Street = "2486 Graham Junction", City = "New Pietro", State = "AE", Zip = "66483" }},
                };

            var results = b.Except(a).ToList();

            Assert.AreEqual(2, results.Count());
            Assert.AreEqual(3, results[0].Id);
            Assert.AreEqual(4, results[1].Id);
        }
    }
}
