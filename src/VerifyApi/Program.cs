using VerifyApi.Data;
using VerifyApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VerifyApiDbContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/verify", ([FromBody] VerifyRequest request) => 
{
    var matcherService = new MatcherService();
    return matcherService.Verify(request);
}).WithName("VerifyFingerprints");

app.Run();

