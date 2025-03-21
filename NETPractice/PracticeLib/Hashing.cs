using System;
using System.Security.Cryptography;
using System.Text;

namespace PracticeLib;

public class Hashing
{
    public static string SHA256AsHex(ref string value) => SHA256AsHex(Encoding.UTF8.GetBytes(value));
    public static string SHA256AsHex(string value) => SHA256AsHex(Encoding.UTF8.GetBytes(value));

    public static string SHA256AsHex(byte[] bytes)
    {
        using SHA256 hashProvider = SHA256.Create();
        var hash = hashProvider.ComputeHash(bytes);

        var sb = new StringBuilder(hash.Length * 2);
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("x2"));
        }

        return sb.ToString();
    }
}
