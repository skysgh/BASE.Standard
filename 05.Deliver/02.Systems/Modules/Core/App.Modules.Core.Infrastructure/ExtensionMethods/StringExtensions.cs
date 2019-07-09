// Copyright MachineBrains, Inc. 2019

using System.Security.Cryptography;
using System.Text;

namespace App
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }

        public static string SplitCamelCase(this string text)
        {
            var result = new StringBuilder();

            var prevChar = (char) 0;

            foreach (var ch in text)
            {
                if (char.IsUpper(ch))
                {
                    if (result.Length > 0)
                    {
                        result.Append(' ');
                    }

                    result.Append(ch);
                }
                else
                {
                    //Lowercase something
                    if (ch != '_')
                    {
                        if (prevChar == '_')
                        {
                            if (result.Length > 0)
                            {
                                result.Append(' ');
                            }

                            result.Append(char.ToUpper(ch));
                        }
                        else
                        {
                            if (result.Length == 0)
                            {
                                result.Append(char.ToUpper(ch));
                            }
                            else
                            {
                                result.Append(ch);
                            }
                        }
                    }
                }

                prevChar = ch;
            }

            var r = result.ToString();
            return r;
        }


        public static byte[] GetHashAsByteArray(this string media, string algorithm = "SHA-256")
        {
            using (var ha = HashAlgorithm.Create(algorithm))
            {
                byte[] hash = ha.ComputeHash(Encoding.UTF8.GetBytes(media));
                return hash;
            }
        }

        public static string GetHashAsString(this string media, string algorithm = "SHA-256")
        {
            byte[] hash = media.GetHashAsByteArray(algorithm);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}