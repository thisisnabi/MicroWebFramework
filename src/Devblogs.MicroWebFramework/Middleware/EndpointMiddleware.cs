namespace Devblogs.MicroWebFramework.Middleware;

public class EndpointMiddleware(Action<HttpListenerContext> next) : MiddlewareBase(next)
{
    private string? GetDefaultAssemblyName => Assembly.GetExecutingAssembly().GetName().Name;

    public override void Handle(HttpListenerContext httpContext)
    {
        var url = httpContext.Request.Url?.AbsolutePath ?? throw new NullReferenceException();

        var parts = url.Split('/');

        var controllerName = parts[1];
        var actionMethod = parts[2];

        //Devblogs.MicroWebFramework.Controllers
        var templateControllerName = $"{GetDefaultAssemblyName}.Controllers.{controllerName}Controller";
        var typeController = Type.GetType(templateControllerName, throwOnError: true, ignoreCase: true);


        MethodInfo method = typeController?.GetMethods()
            .FirstOrDefault(x => String.Compare(x.Name, actionMethod, StringComparison.OrdinalIgnoreCase) == 0) ?? throw new NullReferenceException();

        var instance = Activator.CreateInstance(typeController, new[] { httpContext });
        method.Invoke(instance, null);
    }
}
