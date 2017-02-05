using SimpleUber.Distribution.Host.Authorization;
using SimpleUber.Distribution.Host.ExceptionHandling;
using SimpleUber.Distribution.Host.ExceptionLoggers;
using SimpleUber.Distribution.Host.RequestAndResponseLogging;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;

namespace SimpleUber.Distribution.Host
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var suffix = typeof(DefaultHttpControllerSelector).GetField("ControllerSuffix", BindingFlags.Static | BindingFlags.Public);
            if (suffix != null) suffix.SetValue(null, "Handler");

            // Web API routes
            config.MapHttpAttributeRoutes();

            //ExceptionHandler and ExceptionLoggers registration
            config.Services.Replace(typeof(IExceptionHandler), new SimpleUberExceptionHandler());
            config.Services.Add(typeof(IExceptionLogger), new DbExceptionLogger());

            //Authorization filter registration
            config.Filters.Add(new SimpleUberAuthorizeAttribute());

            //MessageHandlers
            config.MessageHandlers.Add(new RequestAndResponseLogger());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
