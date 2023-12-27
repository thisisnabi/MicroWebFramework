namespace Devblogs.MicroWebFramework.Middleware;

public class EndpointMiddleware : MiddlewareBase
{
     public EndpointMiddleware(Action<HttpListenerContext> next) : base(next)
    {

    }

    public override void Handle(HttpListenerContext httpContext)
    {
        //var url = httpContext.Request.Url.AbsolutePath;

        //var parts = url.Split('/');

        //var controllerClass = parts[1];
        //var actionMethod = parts[2];
        //var userId = parts[3];

        //var templateControllerName = $"PipelineDesignPattern.{controllerClass}Controller";
        //var typeController = Type.GetType(templateControllerName);
        //MethodInfo method = typeController.GetMethod(actionMethod);

        //var parameterInfos = method.GetParameters();

        //var userIdAsInt = Convert.ChangeType(userId, parameterInfos[0].ParameterType);

        //var instance = Activator.CreateInstance(typeController, new[] { httpContext });
        //method.Invoke(instance, new[] { userIdAsInt });

        
    }
}
