using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using SAG.Repositories;
using SAG.Interfaces;
using Autofac.Features.ResolveAnything;
using SAG.Helpers;

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
            builder.RegisterType<ConnectionFactory>().As<IConnectionFactory>().WithParameter("connection", Connection.GetConnectionString);
            builder.RegisterType<UserRepository>().As<IUser>();
            builder.RegisterType<PersonRepository>().As<IPerson>();
            builder.RegisterType<ValidateRepository>().As<IValidate>();
            builder.RegisterType<InfoUserRepository>().As<IInfoUser>();
            builder.RegisterType<MenuRepository>().As<IMenu>();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            Container = builder.Build();
            return Container;
        }
    }
}