using _01_DAL.Classes;
using _02_WebService.Code;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace _02_WebService.Authentication
{
    public class JwtSecurityTokenHandlerAdapter
    {
        private string _jwtSigningKey = "S3tnJUQkJVhiNEpXUC5XfiVYOTV7QVtHXScpYSE2RGM";
        private JwtSecurityTokenHandler _securityTokenHandler;

        public JwtSecurityTokenHandler SecurityTokenHandler
        {
            get
            {
                if (_securityTokenHandler == null)
                {
                    _securityTokenHandler = new JwtSecurityTokenHandler();
                }
                return _securityTokenHandler;
            }
        }


        public JwtSecurityTokenAdapter CreateToken(UserAccount dbUserAccount)
        {
            var bytes = GetBytes(_jwtSigningKey);
            var securityKey = new SymmetricSecurityKey(bytes);

            var claimsList = new List<Claim>();
            claimsList.Add(new Claim(AppUserClaims.UserAccountId, dbUserAccount.Id.ToString()));
            claimsList.Add(new Claim(AppUserClaims.Username, dbUserAccount.Username.ToString()));
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claimsList),
                Expires = DateTime.UtcNow.AddDays(30),
                IssuedAt = DateTime.UtcNow,
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = SecurityTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return new JwtSecurityTokenAdapter(SecurityTokenHandler.WriteToken(token));
        }

        public ClaimsPrincipal ValidateToken(JwtSecurityTokenAdapter securityToken)
        {
            var validationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(GetBytes(_jwtSigningKey))
            };

            SecurityToken validatedToken = null;
            var retval = SecurityTokenHandler.ValidateToken(securityToken.RawData, validationParameters, out validatedToken);
            return retval;
        }

        private byte[] GetBytes(string jwtSigningKey)
        {
            byte[] bytes = new byte[jwtSigningKey.Length * sizeof(char)];
            Buffer.BlockCopy(jwtSigningKey.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
    }
}