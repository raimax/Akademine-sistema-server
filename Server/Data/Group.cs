using System.ComponentModel.DataAnnotations;

namespace Server.Data
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public virtual List<StudentGroup>? StudentGroups { get; set; }
        public virtual List<GroupSubject>? GroupSubjects { get; set; }
    }
}
