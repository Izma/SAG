using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using SAG.Repositories;
using SAG.Interfaces;
using Autofac.Features.ResolveAnything;

namespace SAG
{
    public static class AutofacConfig
    {
        public static void Run()
        {
            Initialize(GlobalConfiguration.Configuration);
        }
        private static IContainer Container { get; set; }

        private static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }
        private static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiModelBinderProvider();
            builder.RegisterType<UserRepository>().As<IUser>().WithParameter("connectionString", Connection.GetConnectionString);
            builder.RegisterType<PersonRepository>().As<IPerson>().WithParameter("connectionString", Connection.GetConnectionString);
            builder.RegisterType<ValidateRepository>().As<IValidate>().WithParameter("connectionString", Connection.GetConnectionString);
            builder.RegisterType<InfoUserRepository>().As<IInfoUser>().WithParameter("connectionString", Connection.GetConnectionString);
            builder.RegisterType<MenuRepository>().As<IMenu>().WithParameter("connectionString", Connection.GetConnectionString);
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            Container = builder.Build();
            return Container;
        }
    }
}