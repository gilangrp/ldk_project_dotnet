using System.ComponentModel.DataAnnotations;

namespace LDKProject.Models.DTO
{
    public class CreateEventRequest
    {
        [Required(ErrorMessage = "Judul Event harus diisi")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Judul Event harus diisi")]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Tanggal Event harus diisi")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Tempat Event harus diisi")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Pembicara harus diisi")]
        public string Speaker { get; set; }
    }
}
