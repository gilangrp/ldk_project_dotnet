using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LDKProject.Models
{
    public class Article
    {
        [Key]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public string CategoryId { get; set; } 
 
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }


}

