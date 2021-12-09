using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public ICollection<string>? Roles { get; set; }
    }
}
