namespace Devblogs.MicroWebFramework.Abstractions;

public class RouteAttribute : Attribute
{
    public RouteAttribute(string path)
    {
        Path = path;
    }

    public string Path { get; set; }
}