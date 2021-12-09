using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Data
{
    public class GroupSubject
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        public virtual Group? Group { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
