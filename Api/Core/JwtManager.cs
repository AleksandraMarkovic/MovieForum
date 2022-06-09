using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core
{
    public class JwtManager
    {
        private readonly MoviesContext _context;
        private readonly string _issuer;
        private readonly string _secretKey;
        public JwtManager(MoviesContext context, string issuer, string secretKey)
        {
            _context = context;
            _issuer = issuer;
            _secretKey = secretKey;
        }

        public string MakeToken(string username, string password)
        {

            var userDatabase = _context.Users.Include(x => x.UserRole)
                .FirstOrDefault(x => x.Username == username && x.Password == password);

            if (userDatabase == null)
            {
                return null;
            }

            var user = new JwtUser();

            //if (userDatabase.RoleId == 1)
            //{
            //    user = new JwtUser
            //    {
            //        Id = userDatabase.Id,
            //        Username = userDatabase.Username,
            //        Role = userDatabase.UserRole.Name
            //    };
            //}
            //else
            //{
            //    user = new JwtUser
            //    {
            //        Id = userDatabase.Id,
            //        Username = userDatabase.Username,
            //        Role = userDatabase.UserRole.Name
            //    };
            //}

            user = new JwtUser
            {
                Id = userDatabase.Id,
                Username = userDatabase.Username,
                Role = userDatabase.UserRole.Name
            };

            var issuer = _issuer;
            var secretKey = _secretKey;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iss, "asp_api", ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, issuer),
                new Claim("UserId", user.Id.ToString(), ClaimValueTypes.String, issuer),
                new Claim("UserData", JsonConvert.SerializeObject(user), ClaimValueTypes.String, issuer),
            };

            claims.Add(new Claim("roles", user.Role));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddSeconds(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
