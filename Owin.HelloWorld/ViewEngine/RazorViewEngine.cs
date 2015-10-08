using System;
using System.Collections.Generic;
using System.IO;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace Owin.HelloWorld.ViewEngine
{
    public class RazorViewEngine : IViewEngine
    {
        public string LayoutViewName { get; set; }
        private readonly ResolvePathTemplateManager templateManager;
        private readonly IRazorEngineService razorEngineService;

        public RazorViewEngine()
            : this("views", "_layout")
        {
        }

        public RazorViewEngine(string viewFolder, string layoutViewName)
        {
            LayoutViewName = layoutViewName;
            var viewFolderFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, viewFolder);

            if (!Directory.Exists(viewFolderFullPath))
                throw new DirectoryNotFoundException("The view folder specified cannot be located.\r\nThe folder should be in the root of your application which was resolved as " + AppDomain.CurrentDomain.BaseDirectory);

            templateManager = new ResolvePathTemplateManager(new[] { viewFolderFullPath });

            var razorEngineConfigCreator = new RazorEngineConfigCreator
            {
                ViewFolder = viewFolderFullPath,
                LayoutViewName = layoutViewName,
            };
            razorEngineService = IsolatedRazorEngineService.Create(razorEngineConfigCreator);
        }

        public string Parse(string viewName)
        {
            return Parse<object>(viewName, null);
        }

        public string Parse<T>(string viewName, T model)
        {
            var templateKey = templateManager.GetKey(viewName.ToLower(), ResolveType.Global, null);
            var data = new DynamicViewBag();
            data.AddValue("Layout", LayoutViewName);
            return razorEngineService.RunCompile(templateKey, typeof (T), model, data);
        }
    }
}
