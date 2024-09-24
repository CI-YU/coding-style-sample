using Autofac;
using interview.Repository.Interface;

namespace interview.Configue;

public class AutofacModuleRegister : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var x = typeof(Program).Assembly;
        builder.RegisterAssemblyTypes(x)
            .Where(t => t.Name.EndsWith("Service"))
            .AsImplementedInterfaces();
        builder.RegisterAssemblyTypes(x)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces();

        builder.RegisterDecorator<CachedUserRepository, IUserRepository>();
    }
}