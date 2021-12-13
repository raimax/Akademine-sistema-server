using System.ComponentModel.DataAnnotations;

namespace Server.Data
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public virtual List<GroupSubject>? GroupSubjects { get; set; }
        public virtual List<StudentGrade>? StudentGrades { get; set; }
    }
}
