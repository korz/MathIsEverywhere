using System;
using Cryptography;

namespace Data
{
    public partial class Customer : IEquatable<Customer>
    {
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public bool Equals(Customer other)
        {
            if (object.ReferenceEquals(this, other)) return true;

            var hash1 = this.ToMd5Hash();
            var hash2 = other.ToMd5Hash();

            return hash1.Equals(hash2);
        }
    }
}
