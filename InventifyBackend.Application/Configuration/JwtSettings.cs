namespace InventifyBackend.Application.Configuration
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public int TimeTokenExpiration { get; set; }
    }
}
