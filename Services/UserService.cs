using Microsoft.EntityFrameworkCore;
using SecureAuthSystem.Data;
using SecureAuthSystem.DTOs;
using SecureAuthSystem.Services.Interface;


namespace SecureAuthSystem.Services
{
    public class UserService : IUserService
    {

        private readonly ApplicationDBContext _context;


        public UserService(ApplicationDBContext context)
        {
            _context = context;
        }


        public async Task<List<UserDto>> GetUsers()
        {

            var users = await _context.Users
                .Include(x => x.Role)
                .Select(x => new UserDto
                {
                    UserId = x.UserId,

                    FullName =
                    x.FirstName + " " + x.LastName,

                    Email = x.Email,

                    Role = x.Role.RoleName

                })
                .ToListAsync();


            return users;

        }





        public async Task<UserDto> GetUserById(int id)
        {

            var user = await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(
                    x => x.UserId == id);


            if (user == null)
            {
                return new UserDto();
            }


            UserDto dto = new UserDto()
            {
                UserId = user.UserId,

                FullName =
                user.FirstName + " " + user.LastName,

                Email = user.Email,

                Role = user.Role.RoleName
            };


            return dto;

        }







        public async Task<string> UpdateUser(
            int id,
            UserDto dto)
        {


            var user =
            await _context.Users.FindAsync(id);



            if (user == null)
            {
                return "User Not Found";
            }



            user.Email = dto.Email;


            await _context.SaveChangesAsync();



            return "User Updated Successfully";

        }








        public async Task<string> DeleteUser(int id)
        {


            var user =
            await _context.Users.FindAsync(id);



            if (user == null)
            {
                return "User Not Found";
            }



            _context.Users.Remove(user);



            await _context.SaveChangesAsync();



            return "User Deleted Successfully";

        }


    }
}