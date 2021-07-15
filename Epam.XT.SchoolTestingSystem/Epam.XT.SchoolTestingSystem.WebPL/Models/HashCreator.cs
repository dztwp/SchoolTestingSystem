using System;
using System.Security.Cryptography;
using System.Text;

namespace Epam.XT.SchoolTestingSystem.WebPL.Models
{
    public static class HashCreator
    {
        public static string GetHash(string pass)
        {
            var sha = SHA256.Create();
            var hash = sha.ComputeHash(Encoding.UTF8.GetBytes(pass));
            return Convert.ToBase64String(hash);

        }
    }
}