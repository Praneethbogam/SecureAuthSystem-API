using System.ComponentModel.DataAnnotations;

namespace SecureAuthSystem.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }


        public int RoleId { get; set; }

        public Role Role { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; }
            = DateTime.Now;
    }
}