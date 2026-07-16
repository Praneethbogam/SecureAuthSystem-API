using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SecureAuthSystem.Services.Interface;

namespace SecureAuthSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboard()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(email))
                return Unauthorized();

            var dashboard = await _dashboardService.GetDashboardAsync(email);

            if (dashboard == null)
                return NotFound();

            return Ok(dashboard);
        }

        [HttpGet("RecentUsers")]
        public async Task<IActionResult> GetRecentUsers()
        {
            var users = await _dashboardService.GetRecentUsersAsync();

            return Ok(users);
        }
    }
}