using Server.Data;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class RemoveGroupSubjectDTO
    {
        [Required]
        public IList<RemoveGroupSubjectAttributes>? GroupSubjects { get; set; }
    }

    public class RemoveGroupSubjectAttributes
    {
        [Required]
        public int Id { get; set; }
    }
}
