using FurnitureSellingCore.DTO.User;
using FurnitureSellingCore.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSellingCore.helper
{
    public static class TokenHelper
    {
        public static string GenerateJwtToken(DetailsUserDTO user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes("LongSeckjhrectStringForModulekodestartppopopopsdfjnshbvhueFGDKJSFBYJDSAGVYKDSGKFUYDGASYGFskc vhHJVCBYHVSKDGHASVBCL");
            var tokenDescriptior = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("UserId",user.UserId+""),
                        new Claim("Email",user.Email),
            
                }),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey)
                , SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptior);
            return tokenHandler.WriteToken(token);
        }
    
        public static bool IsVaildToken(string tokenString)
        {
            String toke = "Bearer " + tokenString;
            var jwtEncodedString = toke.Substring(7);
           var token= new JwtSecurityToken(jwtEncodedString: jwtEncodedString);
            int roleId;
            if (token.ValidTo > DateTime.UtcNow)
            {
                 roleId = Int32.Parse((token.Claims.First(c => c.Type == "UserId").Value.ToString()));
                //valid
                return true;
            }
            else
            {
                return false;

            }

        }

    }
}
