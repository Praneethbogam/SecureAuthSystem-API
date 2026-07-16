using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureAuthSystem.DTOs;
using SecureAuthSystem.Services.Interface;
using System.Security.Claims;


namespace SecureAuthSystem.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserProfileController : ControllerBase
    {


        private readonly IUserProfileService _service;



        public UserProfileController(
            IUserProfileService service)
        {
            _service = service;
        }





        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {


            var email =
                User.FindFirst(
                    ClaimTypes.Email)?.Value;



            if (email == null)
                return Unauthorized();




            var profile =
                await _service.GetProfile(email);



            return Ok(profile);

        }







        [HttpPut]
        public async Task<IActionResult> UpdateProfile(
            UserProfileDto dto)
        {


            var email =
                User.FindFirst(
                    ClaimTypes.Email)?.Value;



            if (email == null)
                return Unauthorized();




            var result =
                await _service.UpdateProfile(
                    email,
                    dto);



            return Ok(result);

        }



    }
}