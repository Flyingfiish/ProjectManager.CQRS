using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ProjectManager.Application
{
    public class AuthOptions
    {
        public const string ISSUER = "ProjectManager"; // издатель токена
        public const string AUDIENCE = "ProjectManager.Client"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
        public const int LIFETIME = 10080; // время жизни токена - 10 дней
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
