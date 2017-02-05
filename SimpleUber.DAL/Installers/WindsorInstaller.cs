using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace SimpleUber.DAL.Installers
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                .Pick().If(t => t.Name.EndsWith("Repository"))
                .WithService.DefaultInterfaces()
                .LifestyleTransient());
        }
    }
}
