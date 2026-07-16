using SecureAuthSystem.DTOs;

namespace SecureAuthSystem.Services.Interface
{
    public interface IUserProfileService
    {

        Task<UserProfileDto> GetProfile(
            string email);


        Task<UserProfileDto> UpdateProfile(
            string email,
            UserProfileDto profileDto);

    }
}