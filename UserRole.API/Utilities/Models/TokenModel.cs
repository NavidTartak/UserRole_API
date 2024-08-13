namespace UserRole.API.Utilities.Models
{
    public class TokenModel
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
