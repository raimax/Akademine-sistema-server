using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Data
{
    public class User : IdentityUser
    {
        public virtual StudentGroup? StudentGroup { get; set; }
        public virtual List<StudentGrade>? StudentGrades { get; set; }
        public virtual List<LecturerSubject>? LecturerSubjects { get; set; }
    }
}
