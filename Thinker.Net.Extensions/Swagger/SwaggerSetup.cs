namespace Thinker.Net.Extensions.Swagger;

public static class SwaggerSetup
{
    public static IServiceCollection AddSwaggerGenEx(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            // 设置标题和版本
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Thinker.Net.API", Version = "v1" });
            // 设置参数默认值
            options.ParameterFilter<DefaultValueParameterFilter>();
            // 设置对象类型参数默认值
            options.SchemaFilter<DefaultValueSchemaFilter>();
            //添加安全定义
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "请输入令牌,格式为 Bearer token（注意中间必须有空格）",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            //添加安全要求
            options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme{
                            Reference =new OpenApiReference{
                                Type = ReferenceType.SecurityScheme,
                                Id ="Bearer"
                            }
                        },Array.Empty<string>()
                    }
                });
        });

        return services;
    }
}
