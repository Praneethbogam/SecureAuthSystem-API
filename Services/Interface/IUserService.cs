using SecureAuthSystem.DTOs;

namespace SecureAuthSystem.Services.Interface
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsers();

        Task<UserDto> GetUserById(int id);

        Task<string> UpdateUser(int id, UserDto dto);

        Task<string> DeleteUser(int id);
    }
}