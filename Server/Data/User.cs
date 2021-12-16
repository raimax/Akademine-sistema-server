using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Data
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public virtual StudentGroup? StudentGroup { get; set; }
        public virtual List<StudentGrade>? StudentGrades { get; set; }
        public virtual LecturerSubject? LecturerSubject { get; set; }
    }
}
