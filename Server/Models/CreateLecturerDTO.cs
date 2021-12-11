using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class CreateLecturerDTO
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
