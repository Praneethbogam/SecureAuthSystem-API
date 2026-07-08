using Microsoft.AspNetCore.Mvc;
using SecureAuthSystem.DTOs;
using SecureAuthSystem.Services.Interface;

namespace SecureAuthSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;


        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }



        // api/auth/register

        [HttpPost("register")]

        public async Task<IActionResult> Register(
            RegisterDto registerDto)
        {

            var result =
                await _authService.Register(registerDto);


            return Ok(new
            {
                Message = result
            });

        }






        // api/auth/login

        [HttpPost("login")]

        public async Task<IActionResult> Login(
            LoginDto loginDto)
        {


            var token =
                await _authService.Login(loginDto);



            if (token == "Invalid User"
               || token == "Invalid Password")
            {

                return Unauthorized(new
                {
                    Message = token
                });

            }




            return Ok(new
            {

                Token = token

            });


        }


    }

}