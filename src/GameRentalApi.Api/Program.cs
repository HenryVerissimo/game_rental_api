using DotNetEnv;
using GameRentalApi.Core.Contracts;
using GameRentalApi.Infrastructure.Data;
using GameRentalApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Configuration.AddEnvironmentVariables();
var connectionString =
    builder.Configuration.GetConnectionString("DB_CONNECTION_STRING")
    ?? Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IRentalGameRepository, RentalGameRepository>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<IVideoGameRepository, VideoGameRepository>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Rental Games API");
    });
}

app.MapControllers();

app.Run();
