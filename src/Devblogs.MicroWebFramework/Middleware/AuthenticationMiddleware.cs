namespace Devblogs.MicroWebFramework.Pipes;

public class AuthenticationMiddleware(Action<HttpListenerContext> next) 
    : MiddlewareBase(next)
{
    public override void Handle(HttpListenerContext httpContext)
    {
        Console.WriteLine("Starting Authentication...");
         
        // do authentication

        if (_next is not null) _next(httpContext);
    }
}