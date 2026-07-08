using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureAuthSystem.DTOs;
using SecureAuthSystem.Services.Interface;


namespace SecureAuthSystem.Controllers
{


    [Authorize]
    [Route("api/[controller]")]
    [ApiController]


    public class UserController : ControllerBase
    {

        private readonly IUserService _service;


        public UserController(IUserService service)
        {
            _service = service;
        }




        [HttpGet]

        public async Task<IActionResult> GetUsers()
        {

            var users =
            await _service.GetUsers();


            return Ok(users);

        }






        [HttpGet("{id}")]

        public async Task<IActionResult> GetUser(int id)
        {

            var user =
            await _service.GetUserById(id);


            return Ok(user);

        }






        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateUser(
            int id,
            UserDto dto)
        {

            var result =
            await _service.UpdateUser(id, dto);



            return Ok(new
            {
                Message = result
            });

        }







        [HttpDelete("{id}")]


        public async Task<IActionResult> DeleteUser(int id)
        {


            var result =
            await _service.DeleteUser(id);



            return Ok(new
            {
                Message = result
            });


        }



    }
}