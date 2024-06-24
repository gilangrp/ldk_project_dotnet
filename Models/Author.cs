using System.ComponentModel.DataAnnotations;

namespace LDKProject.Models
{
    public class Author
    {
        [Key]
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Biography { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? InstagramAccount { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
