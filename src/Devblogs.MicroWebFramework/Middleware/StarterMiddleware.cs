namespace Devblogs.MicroWebFramework.Middleware;

public class StarterMiddleware(Action<HttpListenerContext> next) : MiddlewareBase(next)
{
    public override void Handle(HttpListenerContext httpContext)
    {
        Console.WriteLine($"Start the user request processing process,{httpContext.Request.Url?.AbsolutePath}");
        
        _next(httpContext);
        
        httpContext.Response.Close();
    }
}