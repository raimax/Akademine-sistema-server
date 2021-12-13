using Server.Data;

namespace Server.Models
{
    public class GroupDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<GroupSubjectDTO>? GroupSubjects { get; set; }
    }

    public class GroupSubjectDTO
    {
        public SubjectDTO? Subject { get; set; }
    }

    public class SubjectDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
