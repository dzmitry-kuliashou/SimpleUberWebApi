using System;

namespace SimpleUber.Distribution.Api.Common
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class RouteUriAttribute : Attribute
    {
        private string _uri;

        private HttpMethod _httpMethod;

        public RouteUriAttribute(string uri, HttpMethod httpMethod)
        {
            _uri = uri;
            _httpMethod = httpMethod;
        }

        public string Uri { get { return _uri; } }

        public HttpMethod HttpMethod { get { return _httpMethod; } }
    }
}
