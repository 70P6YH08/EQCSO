using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var jwtOptionsSection = builder.Configuration.GetRequiredSection("Jwt");

var issuer = jwtOptionsSection["Issuer"];
var audience = jwtOptionsSection["Audience"];
var keyStr = jwtOptionsSection["Key"];
var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyStr));

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //CookieAuthenticationDefaults
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


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    return Results.Ok("Привет друг");
});

app.MapGet("/token/{userName}/{userRole}", (string userName, string userRole) =>
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
    return Results.Ok(token);
});


app.MapGet("/user", (HttpContext context) =>
{
    return Results.Ok($"Привет, пользователь" +
        $"{context.User.Identity.Name}" +
        $"({context.User.FindFirst(ClaimTypes.Role).Value})!");
}).RequireAuthorization(p => p.RequireRole("User"));

app.MapGet("/admin", [Authorize(Roles = "Admin")] (HttpContext context) =>
{
    return Results.Ok($"Привет, админ" +
        $"{context.User.Identity.Name}" +
        $"({context.User.FindFirst(ClaimTypes.Role).Value})!");
}).RequireAuthorization(p => p.RequireRole("Admin"));

app.Run();


//string GetToken()
//{
//    var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
//    // создаем JWT-токен
//    var jwt = new JwtSecurityToken(
//            issuer: AuthOptions.ISSUER,
//            audience: AuthOptions.AUDIENCE,
//            claims: claims,
//            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
//            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

//    return new JwtSecurityTokenHandler().WriteToken(jwt);
//}

public class AuthOptions
{
    public const string ISSUER = "MyAuthServer"; // издатель токена
    public const string AUDIENCE = "MyAuthClient"; // потребитель токена
    const string KEY = "mysupersecret_secretsecretsecretkey!123";   // ключ для шифрации
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}