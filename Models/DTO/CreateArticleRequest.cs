using System.ComponentModel.DataAnnotations;

namespace LDKProject.Models.DTO
{
    public class CreateArticleRequest
    {
        [Required(ErrorMessage = "Judul Artikel harus diisi")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Isi harus diisi")]
        public string Content { get; set; }

        [Required(ErrorMessage = "ID Penulis harus diisi")]
        public string AuthorId { get; set; }

        [Required(ErrorMessage = "ID Kategori harus diisi")]
        public string CategoryId { get; set; }


    }
}
