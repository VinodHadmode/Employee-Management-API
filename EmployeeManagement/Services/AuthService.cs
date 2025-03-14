using EmployeeManagement.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagement.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Authenticate(User user)
        {
            // Dummy user validation
            if (user.UserName != "admin" || user.Password != "password")
            {
                return string.Empty;
            }

            // Debugging: Print JWT Configurations
            Console.WriteLine($"JWT Key: {_configuration["Jwt:Key"]}");
            Console.WriteLine($"JWT Issuer: {_configuration["Jwt:Issuer"]}");
            Console.WriteLine($"JWT Audience: {_configuration["Jwt:Audience"]}");

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Role, "Admin")
        };

            var keyBytes = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            Console.WriteLine($"Key Bytes Length: {keyBytes.Length}"); // Log key length

            var key = new SymmetricSecurityKey(keyBytes);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            Console.WriteLine("Token Created Successfully!");

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
