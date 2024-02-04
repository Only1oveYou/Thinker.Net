namespace Thinker.Net.Service;

public class CustomJwtService : ICustomJwtService
{
    private readonly JwtTokenOption _jwtToken;

    public CustomJwtService(IOptionsMonitor<JwtTokenOption> jwtToken)
    {
        _jwtToken = jwtToken.CurrentValue;
    }

    public async Task<string> GetToken(UserRes userRes)
    {
        var res = await Task.Run(() =>
        {
            var claims = new[]
            {
                new Claim("Id",userRes.Id),
                new Claim("Id",userRes.Id),
                    new Claim("NickName",userRes.NickName),
                new Claim("Name",userRes.Name),
                    new Claim("UserType",userRes.UserType.ToString()),
                new Claim("Image",userRes.Image ?? "")
            };

            // encryption
            // Nuget：Microsoft.IdentityModel.Tokens
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtToken.SecurityKey));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Nuget：System.IdentityModel.Tokens.Jwt
            JwtSecurityToken token = new JwtSecurityToken(
                 issuer: _jwtToken.Issuer,
                 audience: _jwtToken.Audience,
                 claims: claims,
                 //10分钟有效期 
                 expires: DateTime.Now.AddMinutes(10),
                 notBefore: null,
                 signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        });

        return res;
    }
}
