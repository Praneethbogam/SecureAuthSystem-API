using Microsoft.EntityFrameworkCore;
using SecureAuthSystem.Data;
using SecureAuthSystem.DTOs;
using SecureAuthSystem.Services.Interface;

namespace SecureAuthSystem.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDBContext _context;

        public DashboardService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<DashboardDto?> GetDashboardAsync(string email)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return null;
            }

            var totalUsers = await _context.Users.CountAsync();

            var totalAdmins = await _context.Users
                .Include(u => u.Role)
                .CountAsync(u => u.Role.RoleName == "Admin");

            var totalNormalUsers = await _context.Users
                .Include(u => u.Role)
                .CountAsync(u => u.Role.RoleName == "User");

            var activeUsers = await _context.Users
                .CountAsync(u => u.IsActive);

            return new DashboardDto
            {
                UserName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                Role = user.Role.RoleName,
                TotalUsers = totalUsers,
                TotalAdmins = totalAdmins,
                TotalNormalUsers = totalNormalUsers,
                ActiveUsers = activeUsers,
                LoginTime = DateTime.Now
            };
        }
            public async Task<List<RecentUserDto>> GetRecentUsersAsync()
        {
            return await _context.Users
                .Include(u => u.Role)
                .OrderByDescending(u => u.CreatedDate)
                .Take(5)
                .Select(u => new RecentUserDto
                {
                    FullName = u.FirstName + " " + u.LastName,
                    Email = u.Email,
                    Role = u.Role.RoleName,
                    IsActive = u.IsActive,
                    CreatedDate = u.CreatedDate
                })
                .ToListAsync();
        }
    }
    
 
}