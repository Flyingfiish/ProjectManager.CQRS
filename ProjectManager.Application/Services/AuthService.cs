using MediatR;
using Microsoft.IdentityModel.Tokens;
using ProjectManager.Application.Queries.Common;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Specifications.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ProjectManager.Application.Services
{
    public class AuthService : IAuthService
    {
        protected IMediator _mediator;

        public AuthService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<string> CreateToken(string login, string password)
        {
            var now = DateTime.UtcNow;

            IEnumerable<Claim> claims = await GetClaims(login, password);

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        private async Task<IEnumerable<Claim>> GetClaims(string login, string password)
        {
            password = GetHash(password);
            IEnumerable<User> result = await _mediator.Send(new ReadQuery<User>(new GetUserByAuthDataSpecification(login, password)));
            User user = result.FirstOrDefault();
            //UserShortDto person = await _usersService.GetShort(new GetUserByLoginPassSpecification(login, PasswordHasher.GetHash(password)));
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, "User"),
                    new Claim("Id", user.Id.ToString())
                };
                return claims;
            }

            // если пользователя не найдено
            return null;
        }

        public string GetHash(string value)
        {

            // generate a 128-bit salt using a secure PRNG
            //byte[] salt = new byte[128 / 8];
            //using (var rng = RandomNumberGenerator.Create())
            //{
            //    rng.GetBytes(salt);
            //}
            //Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");
            var saltStr = "sr2euD5kL3V6BSVcFuCgpA==";
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: value,
                salt: Encoding.UTF8.GetBytes(saltStr),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
