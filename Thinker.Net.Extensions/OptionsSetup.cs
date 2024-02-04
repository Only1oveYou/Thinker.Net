namespace Thinker.Net.Extensions;

public static class OptionsSetup
{
    public static void AddRegisterOptions(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        var optionTypes = typeof(ConfigurableOptions).Assembly.GetTypes()
            .Where(s => !s.IsInterface && typeof(IConfigurableOptions).IsAssignableFrom(s));
       
        foreach (var optionType in optionTypes)
        {
            services.AddConfigurableOptions(optionType);
        }
    }
    
}