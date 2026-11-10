using Microsoft.AspNetCore.Authentication.Negotiate;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate();
builder.Services.AddAuthorization();

var app = builder.Build();

app.MapGet("/profile", (HttpContext context) =>
{
    string userName = context.User.Identity.Name;
    return Results.Ok(userName);
}).RequireAuthorization();

app.MapGet("/students", (HttpContext context) =>
{
    string userName = context.User.Identity.Name;
    return Results.Ok($"Я студент {userName}");
}).RequireAuthorization(policy => policy.RequireRole("PC-KLASS\\Student"));

app.MapGet("/admin", (HttpContext context) =>
{
    string userName = context.User.Identity.Name;
    return Results.Ok($"Я админ {userName}");
}).RequireAuthorization(policy => policy.RequireRole("PC-KLASS\\Admins"));

app.Run();
