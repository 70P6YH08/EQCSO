using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var oauthConfiguration = builder.Configuration.GetRequiredSection("OAuth");

var clientId = oauthConfiguration["ClientId"];
var clientSecret = oauthConfiguration["ClientSecret"];
var callbackPath = oauthConfiguration["CallbackPath"];

var jwtOptionsSection = builder.Configuration.GetRequiredSection("Jwt");

var issuer = jwtOptionsSection["Issuer"];
var audience = jwtOptionsSection["Audience"];
var keyStr = jwtOptionsSection["Key"];
var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyStr));


builder.Services.AddAuthorization(options =>
    options.AddPolicy("Profile", policy => policy
        .AddAuthenticationSchemes(
            JwtBearerDefaults.AuthenticationScheme,
            CookieAuthenticationDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()));

builder.Services.AddAuthentication(options =>
{
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
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = issuer,
            ValidateAudience = true,
            ValidAudience = audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signingKey,
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

app.MapGet("/", () =>
{
    return Results.Ok("Привет друг");
});

app.MapGet("/auth", async context =>
{
    await context.ChallengeAsync("GitHub", new AuthenticationProperties
    {
        RedirectUri = "/profile"
    });
});

app.MapGet("/profile", async (HttpContext context) =>
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
        return Results.Ok($"Привет, {context.User.Identity.Name}" +
            $"({context.User.FindFirst(ClaimTypes.Role).Value})!\n" +
            $"{userData}");
    }
    else
    {
        return Results.Unauthorized();
    }
}).RequireAuthorization("Profile");

app.MapGet("/token/{userName}/{userRole}", async (string userName, string userRole, HttpContext context) =>
{

    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyStr));
    var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

    //var key = Encoding.ASCII.GetBytes(jwtOptionsSection.Key);

    var tokenHandler = new JsonWebTokenHandler();
    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(
        [
            new Claim(ClaimTypes.NameIdentifier, userName),
            new Claim(ClaimTypes.Role, userRole),
        ]),

        Expires = DateTime.UtcNow.AddDays(15),
        Issuer = issuer,
        Audience = audience,
        SigningCredentials = credentials
    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    context.Response.Cookies.Append("jwt", token, new CookieOptions
    {
        HttpOnly = true,
        Secure = true,
        SameSite = SameSiteMode.Lax
    });

    return Results.Redirect("/profile");
});

app.Run();

