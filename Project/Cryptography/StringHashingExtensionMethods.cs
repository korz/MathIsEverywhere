using System.Security.Cryptography;
using System.Text;

namespace Cryptography
{
    public static class StringHashingExtensionMethods
    {
        public static string ToMd5Hash(this string input)
        {
            using (var md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(input.ToBytes());

                var stringBuilder = new StringBuilder();

                for (var i = 0; i < hash.Length; i++)
                {
                    stringBuilder.Append(hash[i].ToString("X2"));
                }

                return stringBuilder.ToString();
            }
        }

        public static byte[] ToBytes(this string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }
    }
}
