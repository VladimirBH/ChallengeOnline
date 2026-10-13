using System.Text;
using Backend.Database;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Experimental;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthorization();

builder.Services.AddOptions<JwtOptions>()
    .Bind(builder.Configuration.GetSection("JwtOptions"))
    .Validate(
        o => !string.IsNullOrEmpty(o.Issuer), "JwtOptions:Issuer не задан")
    .Validate(
        o => !string.IsNullOrEmpty(o.Audience), "JwtOptions:Audience не задан")
    .Validate(
        o => !string.IsNullOrWhiteSpace(o.SecurityKey)
             && Encoding.UTF8.GetByteCount(o.SecurityKey) >= 32,
        "JwtOptions:SecretKey должен содержать минимум 32 байта")
    .Validate(
        o => o.AccessTokenLifetime > 0,
        "Время жизни access token должно быть положительным")
    .ValidateOnStart();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

builder.Services
    .AddOptions<JwtBearerOptions>(
        JwtBearerDefaults.AuthenticationScheme)
    .Configure<IOptions<JwtOptions>>((options, jwtOptions) =>
    {
        var jwt = jwtOptions.Value;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwt.Issuer,
            
            ValidateAudience = true,
            ValidAudience = jwt.Audience,
            
            ValidateLifetime = true,
            RequireExpirationTime = true,
            
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecurityKey)),
            
            ValidAlgorithms = new[] {SecurityAlgorithms.HmacSha512},
            
            ClockSkew = TimeSpan.FromSeconds(30)
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddScoped<UserService>();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ChallengeContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
