namespace LDKProject.Models.Response
{
    public class TokenResponse
    {
        public required string Token { get; set; }

        public required DateTime ExpiresAt { get; set; }

        public required string Role { get; set; }
    }
}
