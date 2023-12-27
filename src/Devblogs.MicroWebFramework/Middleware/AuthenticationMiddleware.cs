namespace Devblogs.MicroWebFramework.Middleware;

public class AuthenticationMiddleware(Action<HttpListenerContext> next) : MiddlewareBase(next)
{
    public override void Handle(HttpListenerContext httpContext)
    {
        _next(httpContext);
    }
}