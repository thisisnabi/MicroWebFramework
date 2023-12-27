namespace Devblogs.MicroWebFramework.Controllers;

public class OrdersController : ControllerBase
{
    public OrdersController(HttpListenerContext httpContext) : base(httpContext)
    {
      
    }

    public void GetAll()
    {
        Console.WriteLine("all orders...");
    }
}
