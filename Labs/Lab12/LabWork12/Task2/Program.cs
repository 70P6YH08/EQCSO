using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var oauthConfiguration = builder.Configuration.GetRequiredSection("OAuth");

var clientId = oauthConfiguration["ClientId"];
var clientSecret = oauthConfiguration["ClientSecret"];
var callbackPath = oauthConfiguration["CallbackPath"];

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = "GitHub";
})
    .AddCookie()
    .AddOAuth("GitHub", options =>
    {
        options.ClientId = clientId!; //Ov23liXKzA8JMUbzCb4e
        options.ClientSecret = clientSecret!; //ae1d12adfd48907ee07f33186e6f0e674e992bb5
        options.CallbackPath = callbackPath;

        options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
        options.TokenEndpoint = "https://github.com/login/oauth/access_token";
        options.UserInformationEndpoint = "https://api.github.com/user";
        options.SaveTokens = true;


        options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
        options.ClaimActions.MapJsonKey(ClaimTypes.Name, "login");

        options.Events = new OAuthEvents
        {
            OnCreatingTicket = async context =>
            {
                var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);
                request.Headers.UserAgent.ParseAdd("TestAppTask2");

                var response = await context.Backchannel.SendAsync(request);
                response.EnsureSuccessStatusCode();

                using var user = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
                context.RunClaimActions(user.RootElement);
            }
        };
    });


builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();


app.MapGet("/auth", async context =>
{
    await context.ChallengeAsync("GitHub", new AuthenticationProperties
    {
        RedirectUri = "/"
    });
});

app.MapGet("/", async (HttpContext context) =>
{
    if (context.User.Identity?.IsAuthenticated == true)
    {
        var name = context.User.Identity.Name;
        var token = await context.GetTokenAsync("access_token");
        using var http = new HttpClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.github.com/users/{name}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        request.Headers.UserAgent.ParseAdd("TestAppTask2");

        var responce = await http.SendAsync(request);
        var json = JsonDocument.ParseAsync(await responce.Content.ReadAsStreamAsync());
        var userData = json.Result;
        return Results.Ok(userData);

    }
    else
    {
        return Results.Unauthorized();
    }
});

app.Run();

