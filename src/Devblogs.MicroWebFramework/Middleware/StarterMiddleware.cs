namespace Devblogs.MicroWebFramework.Pipes;

public class StarterMiddleware(Action<HttpListenerContext> next) : MiddlewareBase(next)
{
    public override void Handle(HttpListenerContext httpContext)
    {
        Console.WriteLine($"Start the user request processing process,{httpContext.Request.Url?.AbsolutePath}");
        
        if (_next is not null)
                _next(httpContext);
        
        httpContext.Response.Close();
    }
}