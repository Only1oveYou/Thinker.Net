namespace Thinker.Net.Extensions.Auth;

public static class AuthenticationSetup
{
    public static IServiceCollection AddAuthenticationEx(this IServiceCollection services)
    {
        var tokenOptions = App.GetOptions<JwtTokenOption>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //是否验证Issuer
                    ValidateIssuer = true,
                    //是否验证Audience
                    ValidateAudience = true,
                    //是否验证失效时间
                    ValidateLifetime = true,
                    //是否验证SecurityKey
                    ValidateIssuerSigningKey = true,
                    ValidAudience = tokenOptions.Audience,//
                    //设置token过期后多久失效，默认过期后300秒内仍有效
                    ClockSkew = TimeSpan.FromSeconds(0),
                    //Issuer，这两项和前面签发jwt的设置一致
                    ValidIssuer = tokenOptions.Issuer,
                    //拿到SecurityKey 
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
                };
            });

        return services;
    }
}
