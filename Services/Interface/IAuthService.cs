using SecureAuthSystem.DTOs;


namespace SecureAuthSystem.Services.Interface
{
    public interface IAuthService
    {

        Task<string> Login(
            LoginDto loginDto);


        Task<string> Register(
            RegisterDto registerDto);

    }
}