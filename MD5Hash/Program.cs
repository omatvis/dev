using Gemstone.StringExtensions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

public static class StringExtens
{
    public static byte[]? ToByteArray(this string str)
    {
        return !string.IsNullOrEmpty(str) ? System.Text.Encoding.UTF8.GetBytes(str) : null;
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }



    private static string ComputeHash(string plainText, string hashAlgorithm = "", string salt = "")
    {
        var plainTextBytes = plainText.ToNonNullString().ToByteArray();
        using var hash = MD5.Create();

        byte[] hashBytes;
        if (string.IsNullOrEmpty(salt))
        {
            hashBytes = hash.ComputeHash(plainTextBytes!);
        } else
        {
            var saltBytes = salt.ToNonNullString().ToByteArray();
            var plainTextWithSaltBytes = new byte[plainTextBytes!.Length + saltBytes!.Length];
        }
    }
}