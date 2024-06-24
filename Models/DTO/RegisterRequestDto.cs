using System.ComponentModel.DataAnnotations;

namespace LDKProject.Models.DTO
{
    public class RegisterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(256)]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(256)]
        public required string Password { get; set; }

        public required int Role { get; set; }  // 0 = user, 1 = admin

    }
}
