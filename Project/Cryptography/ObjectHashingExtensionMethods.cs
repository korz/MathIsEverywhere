using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography
{
    public static class ObjectHashingExtensionMethods
    {
        public static string ToMd5Hash<T>(this T entity)
        {
            using (var md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(entity.ToByteArray());

                var stringBuilder = new StringBuilder();

                for (var i = 0; i < hash.Length; i++)
                {
                    stringBuilder.Append(hash[i].ToString("X2"));
                }

                return stringBuilder.ToString();
            }
        }

        public static byte[] ToByteArray<T>(this T entity)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();

            formatter.Serialize(stream, entity);

            byte[] bytes = stream.ToArray();

            stream.Close();

            return bytes;
        }
    }
}
