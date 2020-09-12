using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Data;
using HomePageVST.Authentication;
using Repositories;
using Repositories.Interfaces;
using Services;
using Services.AutoMapperConfig;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace HomePageVST.App_Start
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<HomePageVSTEntities>().AsSelf().InstancePerRequest();
            builder.RegisterType<UserRoleProvider>().AsSelf().InstancePerRequest();

            RegisterAutoMapper(builder);

            builder.RegisterAssemblyTypes(typeof(DocumentService).Assembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .InstancePerRequest();

            builder.RegisterFilterProvider();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            return container;
        }

        private static void RegisterAutoMapper(ContainerBuilder builder)
        {
            builder.RegisterType<MappingProfile>().As<Profile>();
            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}