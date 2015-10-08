using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Owin;

namespace Owin.HelloWorld.Routing
{
    public class RoutedRequest : OwinRequest
    {
        public RoutedRequest(IDictionary<string, object> env, Regex regex, string path):
            base(env)
        {
            var groups = regex.Match(path).Groups;
            var dic = regex.GetGroupNames().ToDictionary(name => name, name => groups[name].Value);

            UrlSegments = new DynamicDictionary<string>(dic);
        }

        public dynamic UrlSegments { get; private set; }
    }
}
