using RazorEngine.Templating;

namespace Owin.HelloWorld.ViewEngine
{
    public class TemplateBaseWithDefaultLayout<T> : TemplateBase<T>
    {
        public override void SetData(object model, DynamicViewBag viewbag)
        {
            var data = (dynamic)viewbag;

            if (data != null)
            {
                this.Layout = (string)data.Layout;

                // We clear the layout once set in the top-level template
                // to prevent the layouts from referencing themselves / infinite loop
                data.Layout = null;
            }

            base.SetData(model, viewbag);
        }
    }
}