using Server.Data;

namespace Server.Models
{
    public class StudentDTO : PersonDTO
    {
        public StudentGroup? StudentGroup { get; set; }
    }
}
