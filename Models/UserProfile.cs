using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecureAuthSystem.Models
{
    public class UserProfile
    {

        [Key]
        public int ProfileId { get; set; }


        public int UserId { get; set; }


        public string? PhoneNumber { get; set; }


        public string? Address { get; set; }


        public string? City { get; set; }


        public string? Country { get; set; }


        public DateTime UpdatedDate { get; set; }
            = DateTime.Now;



        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}