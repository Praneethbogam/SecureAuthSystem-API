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

        private readonly JwtHelper _jwtHelper;




        public AuthService(
            ApplicationDBContext context,
            JwtHelper jwtHelper)
        {

            _context = context;

            _jwtHelper = jwtHelper;

        }





        public async Task<string> Login(
            LoginDto loginDto)
        {


            var user =
                await _context.Users

                .Include(x => x.Role)

                .FirstOrDefaultAsync(
                    x => x.Email == loginDto.Email);




            if (user == null)
            {
                return null;
            }




            bool verifyPassword =
                BCrypt.Net.BCrypt.Verify(
                    loginDto.Password,
                    user.PasswordHash);




            if (!verifyPassword)
            {
                return null;
            }




            var token =
                _jwtHelper.GenerateToken(user);




            return token;

        }
        public async Task<string> Register(
    RegisterDto registerDto)
        {
            // existing register code

            return "User registered successfully";
        }
    }
}