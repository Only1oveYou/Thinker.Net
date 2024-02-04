namespace Thinker.Net.Extensions.Swagger;

public  class DefaultValueParameterFilter : IParameterFilter
{
    public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
    {
        // 设置普通的string类型默认值
        if (parameter.In == ParameterLocation.Query && parameter.Schema.Type == "string")
        {
            parameter.Example = new OpenApiString("");
        }
    }
}