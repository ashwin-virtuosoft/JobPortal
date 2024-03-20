﻿using System.Security.Cryptography;
using System.Text;

namespace JobPortal.services
{
    public  static class PasswordHash
    {
        public static async Task<string> ToHashSHA1(string Password)
        {
            return await Task.Run(() =>
            {
                using (SHA1Managed sha1 = new SHA1Managed())
                {
                    byte[] bytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(Password));
                    StringBuilder shaBuilder = new StringBuilder();
                    foreach (byte b in bytes)
                    {
                        shaBuilder.Append(b.ToString("x2"));
                    }
                    return shaBuilder.ToString();
                }
            });
        }
    
    public static async Task<string> GenerateSalt()
    {
        int saltLength = new Random().Next(8, 12);
        byte[] salt = new byte[saltLength];
        await Task.Run(() =>
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
        });

        return Convert.ToBase64String(salt);
    }
}
}
