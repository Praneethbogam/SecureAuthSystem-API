
using Microsoft.EntityFrameworkCore;
using SecureAuthSystem.Data;
using SecureAuthSystem.DTOs;
using SecureAuthSystem.Helpers;
using SecureAuthSystem.Models;
using SecureAuthSystem.Services.Interface;

namespace SecureAuthSystem.Services
{
    public class AuthService : IAuthService
    {

        private readonly ApplicationDBContext _context;

        private readonly JWTHelper _jwt;



        public AuthService(
        ApplicationDBContext context,
        JWTHelper jwt)
        {
            _context = context;

            _jwt = jwt;
        }



        public async Task<string> Register(RegisterDto dto)
        {


            User user = new User()
            {

                FirstName = dto.FirstName,

                LastName = dto.LastName,

                Email = dto.Email,

                PasswordHash =
            BCrypt.Net.BCrypt.HashPassword(dto.Password),

                RoleId = 2

            };


            _context.Users.Add(user);

            await _context.SaveChangesAsync();


            return "Registered Successfully";

        }



        public async Task<string> Login(LoginDto dto)
        {

            var user =
            await _context.Users
            .Include(x => x.Role)
            .FirstOrDefaultAsync(
            x => x.Email == dto.Email);



            if (user == null)
                return "Invalid User";



            bool check =
            BCrypt.Net.BCrypt.Verify(
            dto.Password,
            user.PasswordHash);



            if (!check)
                return "Invalid Password";



            return _jwt.GenerateToken(user);


        }



    }
}