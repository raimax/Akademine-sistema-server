using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class RegisterDTO : LoginDTO
    {
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        public ICollection<string>? Roles { get; set; }
    }
}
