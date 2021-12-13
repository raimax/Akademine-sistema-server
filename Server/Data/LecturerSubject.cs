using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Server.Data
{
    public class LecturerSubject
    {
        [Key, ForeignKey("User")]
        public string? Id { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        
        public virtual User? User { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
