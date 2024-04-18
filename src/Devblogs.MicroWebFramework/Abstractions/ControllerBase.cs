namespace Devblogs.MicroWebFramework.Abstractions;

public abstract class ControllerBase(HttpListenerContext httpContext)
{
    protected readonly HttpListenerContext HttpContext = httpContext;
}
