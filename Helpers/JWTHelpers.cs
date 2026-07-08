using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SecureAuthSystem.Models;


namespace SecureAuthSystem.Helpers
{
    public class JWTHelper
    {

        private readonly IConfiguration _config;


        public JWTHelper(IConfiguration config)
        {
            _config = config;
        }



        public string GenerateToken(User user)
        {


            var claims = new[]
            {

new Claim(ClaimTypes.Name,user.Email),

new Claim(
ClaimTypes.Role,
user.Role.RoleName)

};



            var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
            _config["Jwt:Key"]!));


            var creds =
            new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);



            var token = new JwtSecurityToken(

            issuer: _config["Jwt:Issuer"],

            audience: _config["Jwt:Audience"],

            claims: claims,

            expires: DateTime.Now.AddHours(1),

            signingCredentials: creds

            );


            return new JwtSecurityTokenHandler()
            .WriteToken(token);

        }



    }
}