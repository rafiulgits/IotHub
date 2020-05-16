using IotHub.API.Settings;
using IotHub.Common.Extensions;
using IotHub.DataTransferObjects.User;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IotHub.API.Extentions
{
    public static class UserDtoExtension
    {
        public static string GetJwtToken(this UserDto user)
        {
            var jwtSettings = SettingsProvider.JwtSettings;
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.ASCII.GetBytes(jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Role, user.Type.ToIntegerString())
                }),
                Expires = DateTime.UtcNow.AddDays(jwtSettings.LifeTimeDays),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(securityToken);
            return jwtToken;
        }
    }
}
