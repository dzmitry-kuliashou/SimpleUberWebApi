using Castle.Core;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentValidation;
using SimpleUber.Services.Interceptor;

namespace SimpleUber.Services.Installers
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if(WindsorContainer.Container == null)
            {
                WindsorContainer.Container = container;
            }

            container.Register(Component.For<CommandValidationInterceptor>().OnlyNewServices());

            container.Register(
                Classes.FromThisAssembly()
                .Pick().If(t => t.Name.EndsWith("QueryHandler"))
                .WithService.DefaultInterfaces()
                .LifestyleTransient(),
                Classes.FromThisAssembly()
                .Pick().If(t => t.Name.EndsWith("CommandHandler"))
                .WithService.DefaultInterfaces()
                .LifestyleTransient()
                .Configure(delegate(ComponentRegistration c) { var x = c.Interceptors(InterceptorReference.ForType<CommandValidationInterceptor>()).Anywhere; }),
                Classes.FromThisAssembly()
                .Pick().If(t => t.Name.EndsWith("Reader"))
                .WithService.DefaultInterfaces()
                .LifestyleTransient(),
                Classes.FromThisAssembly()
                .Pick().If(t => t.Name.EndsWith("Writer"))
                .WithService.DefaultInterfaces()
                .LifestyleTransient(),
                Classes.FromThisAssembly()
                .BasedOn(typeof(IValidator<>))
                .WithService.AllInterfaces()
                .LifestyleTransient());
        }
    }
}
