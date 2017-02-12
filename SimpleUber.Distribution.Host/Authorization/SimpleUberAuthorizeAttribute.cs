using SimpleUber.Distribution.Host.Installers;
using SimpleUber.Services.Api.Services.Authorisation.QueryHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace SimpleUber.Distribution.Host.Authorization
{
    public class SimpleUberAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly ISessionByTokenQueryHandler _sessionByTokenQueryHandler;

        public SimpleUberAuthorizeAttribute()
        {
            _sessionByTokenQueryHandler = WindsorContainer.Container.Resolve<ISessionByTokenQueryHandler>();
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            IEnumerable<string> tokens;

            if (actionContext.Request.Headers.TryGetValues("Token", out tokens) && tokens.Count() == 1)
            {
                var token = tokens.First();
                var session = _sessionByTokenQueryHandler.Execute(token);

                return session != null && session.TokenExpired >= DateTime.Now;
            }

            return false;
        }
    }
}