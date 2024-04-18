namespace Devblogs.MicroWebFramework.Middleware;

public class EndpointMiddleware : MiddlewareBase
{
    public EndpointMiddleware(Action<HttpListenerContext> next) : base(next)
    {
        _customRoutes = FindAllCustomRoutes();
    }

    private string? GetDefaultAssemblyName => Assembly.GetExecutingAssembly().GetName().Name;
    private readonly Dictionary<string, MethodInfo> _customRoutes;
    private Assembly GetDefaultAssembly => Assembly.GetExecutingAssembly();

    public override void Handle(HttpListenerContext httpContext)
    {
        if (HandleCustomRoutes(httpContext))
            return;

        var url = httpContext.Request.Url?.AbsolutePath ?? throw new NullReferenceException();

        if (_customRoutes.TryGetValue(url, out var actionMethod))
        {
            var actionDeclaringType = actionMethod.DeclaringType ?? throw new NullReferenceException();
            var controllerInstance = Activator.CreateInstance(actionDeclaringType, new { httpContext });
            actionMethod.Invoke(controllerInstance, null);
            return;
        }

        var parts = url.Split('/');

        var controllerName = parts[1];
        var actionMethodName = parts[2];

        //Devblogs.MicroWebFramework.Controllers
        var templateControllerName = $"{GetDefaultAssemblyName}.Controllers.{controllerName}Controller";
        var typeController = Type.GetType(templateControllerName, throwOnError: true, ignoreCase: true);


        var method = typeController?.GetMethods()
                         .FirstOrDefault(x =>
                             string.Compare(x.Name, actionMethodName, StringComparison.OrdinalIgnoreCase) == 0) ??
                     throw new NullReferenceException();

        var instance = Activator.CreateInstance(typeController, new { httpContext });
        method.Invoke(instance, null);
    }

    /// <summary>
    /// Handle request that match with <see cref="_customRoutes"/>
    /// </summary>
    /// <param name="httpContext"></param>
    /// <returns>True if request was handled.</returns>
    /// <exception cref="NullReferenceException">if AbsoluteUrl is null.</exception>
    private bool HandleCustomRoutes(HttpListenerContext httpContext)
    {
        var url = httpContext.Request.Url?.AbsolutePath ?? throw new NullReferenceException();
        url = url.TrimStart('/');
        if (!_customRoutes.TryGetValue(url, out var actionMethod))
            return false;

        var actionDeclaringType = actionMethod.DeclaringType ?? throw new NullReferenceException();
        var controllerInstance = Activator.CreateInstance(actionDeclaringType, new { httpContext });
        actionMethod.Invoke(controllerInstance, null);

        return true;
    }

    /// <summary>
    /// Find All action that inheritance from <see cref="Abstractions.RouteAttribute"/>
    /// </summary>
    /// <returns></returns>
    private Dictionary<string, MethodInfo> FindAllCustomRoutes()
        => GetDefaultAssembly
            .GetTypes()
            .SelectMany(x => x.GetMethods())
            .Where(x => x.GetCustomAttributes(typeof(RouteAttribute), true).Any())
            .Select(method =>
            {
                var customPath = method.GetCustomAttribute<RouteAttribute>()!.Path;
                return (customPath, method);
            })
            .ToDictionary(keySelector => keySelector.customPath, valueSelector => valueSelector.method);

}