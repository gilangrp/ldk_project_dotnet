using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LDKProject.Models;

public class CategoryArticle
{
    [Key]
    public string Id { get; set; }

    public string CategoryName { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

