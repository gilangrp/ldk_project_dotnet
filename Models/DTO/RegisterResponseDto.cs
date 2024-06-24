using System.ComponentModel.DataAnnotations;

namespace LDKProject.Models.DTO
{
    public class RegisterResponseDto
    {
        public required string Email { get; set; }

        public int Roles { get; set; }
    }
}
