using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class AddGradeDTO
    {
        [Required]
        public string? UserId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Pažymys turi būti nuo {1} iki {2}.")]
        public int Grade { get; set; }
    }
}
