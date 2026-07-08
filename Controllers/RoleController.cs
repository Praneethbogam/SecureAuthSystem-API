using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureAuthSystem.DTOs;
using SecureAuthSystem.Services.Interface;


namespace SecureAuthSystem.Controllers
{


    [Authorize(Roles = "Admin")]

    [Route("api/[controller]")]
    [ApiController]


    public class RoleController : ControllerBase
    {


        private readonly IRoleService _roleService;



        public RoleController(
            IRoleService roleService)
        {

            _roleService = roleService;

        }





        // api/role

        [HttpGet]

        public async Task<IActionResult> GetRoles()
        {


            var roles =
                await _roleService.GetRoles();



            return Ok(roles);


        }







        // api/role/add

        [HttpPost("add")]

        public async Task<IActionResult> AddRole(
            RoleDto dto)
        {


            var result =
                await _roleService.AddRole(dto);



            return Ok(new
            {

                Message = result

            });


        }




    }


}