using System;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace Owin.HelloWorld.ViewEngine
{
    [Serializable]
    public class RazorEngineConfigCreator : IsolatedRazorEngineService.IConfigCreator
    {
        public string ViewFolder { get; set; }
        public string LayoutViewName { get; set; }

        public ITemplateServiceConfiguration CreateConfiguration()
        {
            var templateManager = new ResolvePathTemplateManager(new[] { ViewFolder });

            var templateConfiguration = new TemplateServiceConfiguration
            {
                TemplateManager = templateManager,
                BaseTemplateType = typeof(TemplateBaseWithDefaultLayout<>),
            };

            return templateConfiguration;
        }
    }
}