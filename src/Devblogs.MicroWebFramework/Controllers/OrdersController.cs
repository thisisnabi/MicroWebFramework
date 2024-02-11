namespace Devblogs.MicroWebFramework.Controllers;

public class OrdersController(HttpListenerContext httpContext) : ControllerBase(httpContext)
{
    public void GetAll()
    {
        Console.WriteLine("all orders...");
    }
}
