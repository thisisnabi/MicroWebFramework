namespace Devblogs.MicroWebFramework.Middleware;

public class ExceptionHandlingMiddleware(Action<HttpListenerContext> next) : MiddlewareBase(next)
{
    public override void Handle(HttpListenerContext httpContext)
    {
        try
        {
            _next(httpContext);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}