namespace SecureAuthSystem.DTOs
{
    public class DashboardDto
    {
        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public int TotalUsers { get; set; }

        public int TotalAdmins { get; set; }

        public int TotalNormalUsers { get; set; }

        public int ActiveUsers { get; set; }

        public DateTime LoginTime { get; set; }
    }
}