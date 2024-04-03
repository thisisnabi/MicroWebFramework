namespace Devblogs.MicroWebFramework.Controllers;

public class OrdersController(HttpListenerContext httpContext) : ControllerBase(httpContext)
{
    public void GetAll()
    {
        Console.WriteLine("all orders...");
    }

    [Route("custom-url/index")]
    public void CustomRoute()
    {
        Console.WriteLine("Called from custom routing.");
    }
}
