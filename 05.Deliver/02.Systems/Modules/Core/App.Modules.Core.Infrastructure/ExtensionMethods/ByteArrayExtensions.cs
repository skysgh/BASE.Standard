﻿using System.Security.Cryptography;
using System.Text;

namespace App
{
    public static class ByteArrayExtensions
    {
        public static byte[] GetHashAsByteArray(this byte[] media, string algorithm="SHA-256")
        {
            using (var ha = HashAlgorithm.Create(algorithm))
            {
                var hash = ha.ComputeHash(media);
                return hash;
            }

        }
        public static string GetHashAsString(this byte[] media, string algorithm = "SHA-256")
        {
            var hash = media.GetHashAsByteArray(algorithm);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

    }
}
