namespace Devblogs.MicroWebFramework.Controllers;
 
public class ProductsController : ControllerBase
{
    public ProductsController(HttpListenerContext httpContext) : base(httpContext)
    {
      
    }
 
    public void GetAll()
    {
        Console.WriteLine("all products...");
    }
}
