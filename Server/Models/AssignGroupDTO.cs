using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class AssignGroupDTO
    {
        // user id
        [Required]
        public string? UserId { get; set; }
        [Required]
        public int GroupId { get; set; }
    }
}
