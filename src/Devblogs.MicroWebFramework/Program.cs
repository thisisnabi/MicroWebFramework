var hostAddress = "http://localhost:9821/";

var host = new HttpListener();
var requestPipelineStarter = new PipelineBuilder().AddPipe<StarterMiddleware>()
                                                  .AddPipe<ExceptionHandlingMiddleware>()
                                                  .AddPipe<AuthenticationMiddleware>()
                                                  .AddPipe<EndpointMiddleware>()
                                                  .Build();

using (HttpListener listener = new HttpListener())
{
    listener.Prefixes.Add(hostAddress);

    listener.Start();
    Console.WriteLine($"Listening for requests on {hostAddress}");

    while (true)
    {
        var httpContext = listener.GetContext();

        ThreadPool.QueueUserWorkItem((state) =>
        {
            requestPipelineStarter(httpContext);
        });
    }
}

 
