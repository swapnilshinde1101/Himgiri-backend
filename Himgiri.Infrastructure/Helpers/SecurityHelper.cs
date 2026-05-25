using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Himgiri.Infrastructure.Helpers;

public class SecurityHelper
{
    private readonly string _key;
    private readonly string _iv;

    public SecurityHelper(IConfiguration config)
    {
        _key = config["Security:EncryptionKey"] ?? "HimgiriSecurityKey123456789012345"; // 32 chars for AES-256
        _iv = config["Security:EncryptionIV"] ?? "HimgiriSecurityIV";                 // 16 chars
    }

    public string Encrypt(string plainText)
    {
        if (string.IsNullOrEmpty(plainText)) return plainText;

        using Aes aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(_key.PadRight(32).Substring(0, 32));
        aes.IV = Encoding.UTF8.GetBytes(_iv.PadRight(16).Substring(0, 16));

        ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

        using MemoryStream ms = new();
        using (CryptoStream cs = new(ms, encryptor, CryptoStreamMode.Write))
        {
            using (StreamWriter sw = new(cs))
            {
                sw.Write(plainText);
            }
        }

        return Convert.ToBase64String(ms.ToArray());
    }

    public string Decrypt(string cipherText)
    {
        if (string.IsNullOrEmpty(cipherText)) return cipherText;

        using Aes aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(_key.PadRight(32).Substring(0, 32));
        aes.IV = Encoding.UTF8.GetBytes(_iv.PadRight(16).Substring(0, 16));

        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

        using MemoryStream ms = new(Convert.FromBase64String(cipherText));
        using CryptoStream cs = new(ms, decryptor, CryptoStreamMode.Read);
        using StreamReader sr = new(cs);
        
        return sr.ReadToEnd();
    }
}
