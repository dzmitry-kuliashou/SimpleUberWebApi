using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;

namespace SimpleUber.Config.Installers
{
    public static class InstallWindsorRegistrators
    {
        public static void Install(IWindsorContainer container)
        {
            var applicationPhysicalPath = "D:\\Programming\\WebApi\\SimpleUberWebApi\\SimpleUber.Config\\bin\\Debug";

            container.Install(
                    FromAssembly.InDirectory(new AssemblyFilter(applicationPhysicalPath, "*.dll"))
                    );
        }
    }
}
