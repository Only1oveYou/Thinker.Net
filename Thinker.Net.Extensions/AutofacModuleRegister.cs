namespace Thinker.Net.Extensions;

public class AutofacModuleRegister : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var basePath = AppContext.BaseDirectory;
        var serviceDllPath = Path.Combine(basePath, "Thinker.Net.Service.dll");
        var repositoryDllPath = Path.Combine(basePath, "Thinker.Net.Repository.dll");
        var serviceAss = Assembly.LoadFrom(serviceDllPath);
        var repositoryAss = Assembly.LoadFrom(repositoryDllPath);

        builder.RegisterGeneric(typeof(BaseService<,>)).As(typeof(IBaseService<,>))
          .InstancePerDependency();

        builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>))
            .InstancePerDependency();

        builder.RegisterAssemblyTypes(serviceAss)
            .AsImplementedInterfaces()
            .PropertiesAutowired()
            .InstancePerDependency();

        builder.RegisterAssemblyTypes(repositoryAss)
            .AsImplementedInterfaces()
            .PropertiesAutowired()
            .InstancePerDependency();

      
    }
}