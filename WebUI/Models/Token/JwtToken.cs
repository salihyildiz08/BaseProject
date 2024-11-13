namespace WebUI.Models.Token
{
    public class JwtToken
    {
        public TokenInfo Token { get; set; }
    }

    public class TokenInfo
    {
        public string Result { get; set; }
    }
}
