using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class CreateGroupDTO
    {
        [Required]
        public string? Name { get; set; }
    }
}
