using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class CreateSubjectDTO
    {
        [Required]
        public string? Name { get; set; }
    }
}
