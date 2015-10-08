namespace Owin.HelloWorld.ViewEngine
{
    public interface IViewEngine
    {
        string Parse(string viewName);
        string Parse<T>(string viewName, T model);
    }
}
