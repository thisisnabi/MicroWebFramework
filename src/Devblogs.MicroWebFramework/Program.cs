var hostAddress = "http://localhost:9821/";

var requestPipelineStarter = new PipelineBuilder().AddPipe<StarterMiddleware>()
                                                  .AddPipe<ExceptionHandlingMiddleware>()
                                                  .AddPipe<AuthenticationMiddleware>()
                                                  .AddPipe<EndpointMiddleware>()
                                                  .Build();

using (HttpListener host = new HttpListener())
{
    host.Prefixes.Add(hostAddress);

    host.Start();
    Console.WriteLine($"Listening for requests on {hostAddress}");

    while (true)
    {
        var httpContext = await host.GetContextAsync();

        ThreadPool.QueueUserWorkItem((state) =>
        {
            requestPipelineStarter(httpContext);
        });
    }
}

 
