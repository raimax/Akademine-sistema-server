using System.ComponentModel.DataAnnotations;

namespace Server.Data
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public virtual GroupSubject? GroupSubject { get; set; }
        public virtual List<StudentGrade>? StudentGrades { get; set; }
    }
}
