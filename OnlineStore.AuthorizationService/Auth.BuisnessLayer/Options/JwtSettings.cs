namespace Auth.BuisnessLayer.Options
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string NameClaim { get; set; }
        public string RoleClaim { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}