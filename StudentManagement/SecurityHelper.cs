using System.Security.Cryptography;
using System.Text;

namespace StudentManagement
{
    public static class SecurityHelper
    {
        public static string HashPassword(string plain)
        {
            using SHA256 sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(plain));
            return Convert.ToHexString(bytes).ToLower();
        }
    }
}
