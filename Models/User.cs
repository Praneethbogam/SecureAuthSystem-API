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



        // Foreign Key for Role
        public int RoleId { get; set; }


        // Navigation property for Role
        public Role Role { get; set; }



        public bool IsActive { get; set; } = true;


        public DateTime CreatedDate { get; set; }
            = DateTime.Now;



        // Navigation property for UserProfile vcx
        public UserProfile UserProfile { get; set; }
    }
}
