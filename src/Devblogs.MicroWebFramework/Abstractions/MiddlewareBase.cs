namespace Devblogs.MicroWebFramework.Abstractions;

public abstract class MiddlewareBase(Action<HttpListenerContext> next)
{
    public Action<HttpListenerContext> _next = next;

    public abstract void Handle(HttpListenerContext httpContext);
}