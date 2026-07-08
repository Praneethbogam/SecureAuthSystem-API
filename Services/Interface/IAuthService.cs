using SecureAuthSystem.DTOs;

namespace SecureAuthSystem.Services.Interface
{
    public interface IAuthService
    {

        Task<string> Register(RegisterDto dto);


        Task<string> Login(LoginDto dto);

    }
}