using Castle.Windsor;
using SimpleUber.Distribution.Host.Installers;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace SimpleUber.Distribution.Host
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private readonly IWindsorContainer _container;

        public WebApiApplication()
        {
            _container = Installers.WindsorContainer.Container;

            var configAssembly = Assembly.Load("SimpleUber.Config");
            var installWindsorRegistratorsClass = configAssembly.GetType("SimpleUber.Config.Installers.InstallWindsorRegistrators");
            installWindsorRegistratorsClass.GetMethod("Install", BindingFlags.Public | BindingFlags.Static).Invoke(null, new object[] {_container});
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            GlobalConfiguration.Configuration.Services.Replace(typeof(IAssembliesResolver), new CustomAssemblyResolver());

            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new WindsorCompositionRoot(_container));
        }

        public override void Dispose()
        {
            _container.Dispose();
            base.Dispose();
        }
    }
}
