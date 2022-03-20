var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", ([FromBody] VerifyRequest request) => 
{
    var matcherService = new MatcherService();
    return matcherService.Verify(request);
});

app.Run();
