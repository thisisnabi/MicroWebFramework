namespace Devblogs.MicroWebFramework.Pipes;

public class StarterMiddleware(Action<HttpListenerContext> next) 
    : MiddlewareBase(next)
{
    public override void Handle(HttpListenerContext httpContext)
    {
        Console.WriteLine("Starting Authentication...");
 
        if (_next is not null) _next(httpContext);
    }
}