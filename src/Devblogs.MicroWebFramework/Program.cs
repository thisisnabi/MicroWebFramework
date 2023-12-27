
var httpListiner = new HttpListener();

var httpPrefix = "http://localhost:9821/";

httpListiner.Prefixes.Add(httpPrefix);


Console.WriteLine($"start listening to {httpPrefix} ...");
httpListiner.Start();

var httpContext = httpListiner.GetContext();


 
var requestPipelineStarter = new PipelineBuilder().AddPipe<StarterMiddleware>()
                                                  .AddPipe<ExceptionHandlingMiddleware>()
                                                  .AddPipe<AuthenticationMiddleware>()
                                                  .AddPipe<EndpointMiddleware>()
                                                  .Build();

requestPipelineStarter(httpContext);