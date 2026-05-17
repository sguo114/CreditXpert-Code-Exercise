using Microsoft.OpenApi;
using problem1_RestfulAPI.Repositories;
using problem1_RestfulAPI.Repositories.Abstractions;
using problem1_RestfulAPI.Services;
using problem1_RestfulAPI.Services.Contracts;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, _, _) =>
    {
        var isCloud = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PORT"));
        if (isCloud)
        {
            document.Servers = new List<OpenApiServer> { new() { Url = "https://credit-account-api.up.railway.app" } };
        }
        return Task.CompletedTask;
    });
});

builder.Services.AddSingleton<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");
var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.MapControllers();

app.Run();