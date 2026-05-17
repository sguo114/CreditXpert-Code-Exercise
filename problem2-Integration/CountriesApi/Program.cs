using CountriesApi.Services;
using CountriesApi.Services.Abstractions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddHttpClient<ICountryService, CountryService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173") 
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}
app.UseCors("AllowReactApp");
app.MapControllers();
app.Run();