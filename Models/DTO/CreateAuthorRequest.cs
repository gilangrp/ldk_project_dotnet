using System.ComponentModel.DataAnnotations;

namespace LDKProject.Models.DTO
{
    public class CreateAuthorRequest
    {
        [Required(ErrorMessage = "Nama harus diisi")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Biografi harus diisi")]
        public string Biography { get; set; }

        [Required(ErrorMessage = "Tanggal Lahir harus diisi")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_]*$", ErrorMessage = "Format Instagram Account tidak valid")]
        public string? InstagramAccount { get; set; }
    }
}
