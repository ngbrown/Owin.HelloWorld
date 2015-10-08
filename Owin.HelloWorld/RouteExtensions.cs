using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Owin.HelloWorld
{
    public static class RouteExtensions
    {
        public static void Json(this IOwinResponse res, dynamic obj, bool useJavaScriptNaming = true)
        {
            res.ContentType = "application/json";
            res.StatusCode = 200;

            var serializer = new JsonSerializer();

            if (useJavaScriptNaming)
                serializer.ContractResolver = new CamelCasePropertyNamesContractResolver();

            res.Write(JObject.FromObject(obj, serializer).ToString());
        }

        public static void Text(this IOwinResponse res, string text)
        {
            res.ContentType = "text/plain";
            res.StatusCode = 200;
            res.Write(text);
        }
    }
}
