using DamlaProje.Blog.Business.StringInfos;
using DamlaProje.Blog.Entities.Concrete;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DamlaProje.Blog.Business.Tools.JWTTool
{
    public class JwtManager : IJwtService
    {
        private readonly IOptions<JwtInfo> _optionsJwt;
        public JwtManager(IOptions<JwtInfo> optionsJwt)
        {
            _optionsJwt = optionsJwt;
        }
        public JwtToken GenerateJwt(AppUser appUser)
        {
            var jwtInfo = _optionsJwt.Value;
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtInfo.SecurityKey));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: jwtInfo.Issuer,audience: jwtInfo.Audience,claims:SetClaims(appUser),notBefore:DateTime.Now,expires:DateTime.Now.AddMinutes(jwtInfo.Expires),signingCredentials:signingCredentials);
            JwtToken jwtToken = new JwtToken(); 
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            jwtToken.Token = handler.WriteToken(jwtSecurityToken);
            return jwtToken;
        }
        private List<Claim> SetClaims(AppUser appUser) 
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));
            return claims;
        }
    }
}
