namespace Devblogs.MicroWebFramework.Abstractions;

public abstract class ControllerBase
{
    protected readonly HttpListenerContext HttpContext;

    public ControllerBase(HttpListenerContext httpContext)
    {
        HttpContext = httpContext;
    }
}
