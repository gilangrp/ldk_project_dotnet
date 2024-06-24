using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LDKProject.Models.DTO
{
    public class UserDto : IdentityUser
    {
        [Key]
        public string Id { get; set; }

        public string? Email { get; set; }

        public string? PasswordHash { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
