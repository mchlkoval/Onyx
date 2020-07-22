using Application.Interfaces.JWT;
using Domain.Identity;
using Microsoft.IdentityModel.Tokens;
using Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.InterfaceImplementor.Security.JWT
{
    public class JWTGenerator : IJWTGenerator
    {
        private string TypeOfUser(UserType type)
        {
            switch(type)
            {
                case UserType.Athlete:
                    return "Athlete";
                case UserType.Coach:
                    return "Coach";
                case UserType.Manager:
                    return "Admin";
                default:
                    return "Athlete";
            }
        }

        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName),
                new Claim("OrgId", user.OrganizationId),
                new Claim("UserType", TypeOfUser(user.UserType))
            };

            // Generate signing credentials
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super Secret Dev Key"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
