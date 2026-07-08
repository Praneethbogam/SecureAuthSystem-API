using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace SecureAuthSystem.Controllers
{


    [Route("api/[controller]")]
    [ApiController]


    public class DashboardController : ControllerBase
    {




        // api/dashboard/profile


        [Authorize]

        [HttpGet("profile")]

        public IActionResult Profile()
        {



            var username =
            User.FindFirst(
            ClaimTypes.Name)?.Value;




            var role =
            User.FindFirst(
            ClaimTypes.Role)?.Value;





            return Ok(new
            {

                Message = "Welcome User",

                User = username,

                Role = role

            });



        }







        // api/dashboard/admin


        [Authorize(Roles = "Admin")]

        [HttpGet("admin")]


        public IActionResult AdminDashboard()
        {



            return Ok(new
            {

                Message =
                "Welcome Admin Dashboard"


            });



        }









        // api/dashboard/user


        [Authorize(Roles = "User")]

        [HttpGet("user")]


        public IActionResult UserDashboard()
        {


            return Ok(new
            {

                Message =
                "Welcome User Dashboard"

            });



        }



    }


}