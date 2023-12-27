namespace Devblogs.MicroWebFramework.Abstractions;

public class PipelineBuilder
{
    private List<Type> _pipes = new();
     
    public PipelineBuilder AddPipe<TType>()
        where TType : MiddlewareBase
    {
        _pipes.Add(typeof(TType));
        return this;
    }

    public Action<HttpListenerContext> Build()
    {
        var fakeHandler = (HttpListenerContext httpContext) => { };
        var latestIndex = _pipes.Count - 1;

        var selectedPipe = (MiddlewareBase)Activator.CreateInstance(_pipes[latestIndex], new[] { fakeHandler })!;

        for (int index = latestIndex - 1; index > 0; index--)
        {
            selectedPipe = (MiddlewareBase)Activator.CreateInstance(_pipes[index], new[] { selectedPipe.Handle })!;
        }

        var firstPipe = (MiddlewareBase)Activator.CreateInstance(_pipes[0], new[] { selectedPipe.Handle })!;
        return firstPipe.Handle;
    }
}
