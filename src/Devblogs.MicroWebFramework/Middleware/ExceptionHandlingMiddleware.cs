namespace Devblogs.MicroWebFramework.Pipes;

public class ExceptionHandlingMiddleware(Action<HttpListenerContext> next) 
    : MiddlewareBase(next)
{
    public override void Handle(HttpListenerContext httpContext)
    {
        try
        {
            Console.WriteLine("Starting ExceptionHandling...");

            if (_next is not null) _next(httpContext);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}