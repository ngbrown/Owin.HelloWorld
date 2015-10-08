using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace Owin.HelloWorld.Routing
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public static class Middleware
    {
        public static IAppBuilder Get(this IAppBuilder builder, Action<IOwinRequest, IOwinResponse> app)
        {
            return builder.Use(new Func<AppFunc, AppFunc>(next => (async env =>
            {
                if ((string)env["owin.RequestMethod"] == "GET")
                {
                    var req = new OwinRequest(env);
                    var res = new OwinResponse(env);
                    app(req, res);

                }
                else
                {
                    await next.Invoke(env);
                }
            })));
        }

        public static IAppBuilder Post(this IAppBuilder builder, Action<IOwinRequest, IOwinResponse> app)
        {
            return builder.Use(new Func<AppFunc, AppFunc>(next => (async env =>
            {
                if ((string)env["owin.RequestMethod"] == "POST")
                {
                    var req = new OwinRequest(env);
                    var res = new OwinResponse(env);
                    app(req, res);

                }
                else
                {
                    await next.Invoke(env);
                }
            })));
        }

        public static IAppBuilder Put(this IAppBuilder builder, Action<IOwinRequest, IOwinResponse> app)
        {
            return builder.Use(new Func<AppFunc, AppFunc>(next => (async env =>
            {
                if ((string)env["owin.RequestMethod"] == "PUT")
                {
                    var req = new OwinRequest(env);
                    var res = new OwinResponse(env);
                    app(req, res);

                }
                else
                {
                    await next.Invoke(env);
                }
            })));
        }

        public static IAppBuilder Delete(this IAppBuilder builder, Action<IOwinRequest, IOwinResponse> app)
        {
            return builder.Use(new Func<AppFunc, AppFunc>(next => (async env =>
            {
                if ((string)env["owin.RequestMethod"] == "DELETE")
                {
                    var req = new OwinRequest(env);
                    var res = new OwinResponse(env);
                    app(req, res);

                }
                else
                {
                    await next.Invoke(env);
                }
            })));
        }

        public static IAppBuilder Patch(this IAppBuilder builder, Action<IOwinRequest, IOwinResponse> app)
        {
            return builder.Use(new Func<AppFunc, AppFunc>(next => (async env =>
            {
                if ((string)env["owin.RequestMethod"] == "PATCH")
                {
                    var req = new OwinRequest(env);
                    var res = new OwinResponse(env);
                    app(req, res);

                }
                else
                {
                    await next.Invoke(env);
                }
            })));
        }
    }
}
