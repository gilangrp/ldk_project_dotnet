using System.ComponentModel.DataAnnotations;

namespace LDKProject.Models
{
    public class UserProfile
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public IList<string> Role { get; set; }


    }
}
