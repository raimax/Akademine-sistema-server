using Server.Data;

namespace Server.Models
{
    public class LecturerDTO : PersonDTO
    {
        public LecturerSubject? LecturerSubject { get; set; }
    }
}
