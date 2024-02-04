namespace Thinker.Net.Common.Options;

public class JwtTokenOption : IConfigurableOptions
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public string SecurityKey { get; set; }
}
