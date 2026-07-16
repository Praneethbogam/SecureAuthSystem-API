using SecureAuthSystem.DTOs;

namespace SecureAuthSystem.Services.Interface
{
    public interface IDashboardService
    {
        Task<DashboardDto?> GetDashboardAsync(string email);

        Task<List<RecentUserDto>> GetRecentUsersAsync();
    }
}