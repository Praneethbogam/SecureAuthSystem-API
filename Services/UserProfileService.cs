using Microsoft.EntityFrameworkCore;
using SecureAuthSystem.Data;
using SecureAuthSystem.DTOs;
using SecureAuthSystem.Models;
using SecureAuthSystem.Services.Interface;


namespace SecureAuthSystem.Services
{
    public class UserProfileService
        : IUserProfileService
    {

        private readonly ApplicationDBContext _context;



        public UserProfileService(
            ApplicationDBContext context)
        {
            _context = context;
        }




        public async Task<UserProfileDto> GetProfile(
            string email)
        {


            var user = await _context.Users
                .Include(x => x.Role)
                .Include(x => x.UserProfile)
                .FirstOrDefaultAsync(
                    x => x.Email == email);



            if (user == null)
                return null;



            return new UserProfileDto()
            {

                FirstName = user.FirstName,


                LastName = user.LastName,


                Email = user.Email,


                Role = user.Role.RoleName,


                PhoneNumber =
                    user.UserProfile?.PhoneNumber,


                Address =
                    user.UserProfile?.Address,


                City =
                    user.UserProfile?.City,


                Country =
                    user.UserProfile?.Country

            };


        }


        public async Task<UserProfileDto> UpdateProfile(
            string email,
            UserProfileDto dto)
        {


            var user = await _context.Users
                .Include(x => x.UserProfile)
                .FirstOrDefaultAsync(
                    x => x.Email == email);



            if (user == null)
                return null;



            if (user.UserProfile == null)
            {

                user.UserProfile =
                    new UserProfile()
                    {
                        UserId = user.UserId
                    };

            }



            user.FirstName = dto.FirstName;

            user.LastName = dto.LastName;



            user.UserProfile.PhoneNumber =
                dto.PhoneNumber;


            user.UserProfile.Address =
                dto.Address;


            user.UserProfile.City =
                dto.City;


            user.UserProfile.Country =
                dto.Country;


            user.UserProfile.UpdatedDate =
                DateTime.Now;




            await _context.SaveChangesAsync();



            return dto;

        }

    }
}