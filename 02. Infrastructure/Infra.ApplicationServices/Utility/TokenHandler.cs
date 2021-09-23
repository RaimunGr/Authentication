using Core.DomainModel.UserAggregate.Entities;
using Infra.ApplicationServices.Dtos;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infra.ApplicationServices.Utility
{
    public static class TokenHandler
    {
        public const string ISSUER = "https://raimun.com/";
        public const string AUDIENCE = "https://raimun.com/";

        public static TokenDto CreateFromUser(string secret, User user)
        {
            if (string.IsNullOrWhiteSpace(secret) || user is null)
            {
                throw new Exception("secret and user can NOT be null.");
            }

            var tokenDescriptor = FillToken(secret, user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenDto
            {
                Username = user.Username,
                Token = tokenHandler.WriteToken(jwt)
            };
        }

        public static bool Validate(string secret, string token)
        {
            if (string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("secret and token can NOT be null.");
            }

            var secretBytes = Encoding.ASCII.GetBytes(secret);
            var securityKey = new SymmetricSecurityKey(secretBytes);

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidAudience = AUDIENCE,
                    ValidIssuer = ISSUER,
                    IssuerSigningKey = securityKey
                }, out SecurityToken validatedToken);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static SecurityTokenDescriptor FillToken(string secret, User user)
        {
            var expiryInMin = 30;
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));

            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(RaimunClaimTypes.Id, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(RaimunClaimTypes.Username, user.Username),
                }),
                Expires = DateTime.UtcNow.AddMinutes(expiryInMin),
                Issuer = ISSUER,
                Audience = AUDIENCE,
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
        }
    }
}
