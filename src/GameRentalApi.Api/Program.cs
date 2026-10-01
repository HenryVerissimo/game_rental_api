using System.Text;
using DotNetEnv;
using GameRentalApi.Core.Contracts;
using GameRentalApi.Core.Services;
using GameRentalApi.Infrastructure.Data;
using GameRentalApi.Infrastructure.Repositories;
using GameRentalApi.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

builder.Configuration.AddEnvironmentVariables();
var connectionString =
    builder.Configuration.GetConnectionString("DB_CONNECTION_STRING")
    ?? Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

string jwtSecretKey = builder.Configuration["JWT:SECRETKEY"]
    ?? throw new InvalidOperationException("Environment variable JWT__SECRETKEY not implemented!");

int jwtExpireInMinutes = Convert.ToInt32(builder.Configuration["JWT:EXPIREINMINUTES"]
    ?? throw new InvalidOperationException("Environment variable JWT__EXPIREINMINUTES not implemented!"));

string jwtIssuer = builder.Configuration["JWT:ISSUER"]
    ?? throw new InvalidOperationException("Environment variable JWT__ISSUER not implemented!");

string jwtAudience = builder.Configuration["JWT:AUDIENCE"]
    ?? throw new InvalidOperationException("Environment variable JWT__AUDIENCE not implemented!");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtIssuer,
            ValidateAudience = true,
            ValidAudience = jwtAudience,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey)),
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IRentalGameRepository, RentalGameRepository>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<IVideoGameRepository, VideoGameRepository>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IRentalGameService, RentalGameService>();
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<IVideoGameService, VideoGameService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Rental Games API");
    });
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
