using System.ComponentModel.DataAnnotations;

namespace LDKProject.Models.DTO;

public class CreateCategoryArticleRequest
{
    [Required(ErrorMessage = "Kategori Artikel harus diisi")]
    public string CategoryName { get; set; }

}

