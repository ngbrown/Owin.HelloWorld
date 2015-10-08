using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace Owin.HelloWorld.Routing
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public static class Routing
    {
        private static AppFunc ProcessRequest(AppFunc next, Regex regex, string method, Action<RoutedRequest, IOwinResponse> app)
        {
            return async env =>
            {
                var path = (string)env["owin.RequestPath"];

                if (path.EndsWith("/"))
                    path = path.TrimEnd('/');

                if ((string)env["owin.RequestMethod"] == method && regex.IsMatch(path))
                {
                    var req = new RoutedRequest(env, regex, path);
                    var res = new OwinResponse(env);
                    app(req, res);
                }
                else
                {
                    await next.Invoke(env);
                }
            };
        }

        public static IAppBuilder Get(this IAppBuilder builder, string route, Action<RoutedRequest, IOwinResponse> app)
        {
            var regex = RouteBuilder.RouteToRegex(route);

            return builder.Use(new Func<AppFunc, AppFunc>(next => ProcessRequest(next, regex, "GET", app)));
        }

        public static IAppBuilder Post(this IAppBuilder builder, string route, Action<RoutedRequest, IOwinResponse> app)
        {
            var regex = RouteBuilder.RouteToRegex(route);

            return builder.Use(new Func<AppFunc, AppFunc>(next => ProcessRequest(next, regex, "POST", app)));
        }

        public static IAppBuilder Put(this IAppBuilder builder, string route, Action<RoutedRequest, IOwinResponse> app)
        {
            var regex = RouteBuilder.RouteToRegex(route);

            return builder.Use(new Func<AppFunc, AppFunc>(next => ProcessRequest(next, regex, "PUT", app)));
        }

        public static IAppBuilder Delete(this IAppBuilder builder, string route, Action<RoutedRequest, IOwinResponse> app)
        {
            var regex = RouteBuilder.RouteToRegex(route);

            return builder.Use(new Func<AppFunc, AppFunc>(next => ProcessRequest(next, regex, "DELETE", app)));
        }

        public static IAppBuilder Patch(this IAppBuilder builder, string route, Action<RoutedRequest, IOwinResponse> app)
        {
            var regex = RouteBuilder.RouteToRegex(route);

            return builder.Use(new Func<AppFunc, AppFunc>(next => ProcessRequest(next, regex, "PATCH", app)));
        }
    }
}
