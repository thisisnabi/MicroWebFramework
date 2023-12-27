namespace Devblogs.MicroWebFramework.Abstractions;

public abstract class MiddlewareBase
{
    public Action<HttpListenerContext> _next;

    public MiddlewareBase(Action<HttpListenerContext> next)
    {
        _next = next;
    }

    public abstract void Handle(HttpListenerContext httpContext);
}