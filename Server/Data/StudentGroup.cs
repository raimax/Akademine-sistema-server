using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Data
{
    public class StudentGroup
    {
        [Key, ForeignKey("User")]
        public string? UserId { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }

        public virtual Group? Group { get; set; }
        public virtual User? User { get; set; }
    }
}
