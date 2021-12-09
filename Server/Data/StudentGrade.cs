using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Data
{
    public class StudentGrade
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        public int Grade { get; set; }

        public virtual User? User { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
