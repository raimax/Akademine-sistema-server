using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class AssignSubjectDTO
    {
        // user id
        [Required]
        public string? Id { get; set; }
        [Required]
        public int SubjectId { get; set; }
    }
}
