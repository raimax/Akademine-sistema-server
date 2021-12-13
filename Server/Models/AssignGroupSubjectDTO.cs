using Server.Data;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class AssignGroupSubjectDTO
    {
        [Required]
        public IList<AssignGroupSubjectAttributes>? GroupSubjects { get; set; }
    }

    public class AssignGroupSubjectAttributes
    {
        [Required]
        public int GroupId { get; set; }
        [Required]
        public int SubjectId { get; set; }
    }
}
