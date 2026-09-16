using GameRentalApi.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GameRentalApi.Infrastructure.Data;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<Game> Games { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<RentalGame> RentalGames { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<VideoGame> VideoGames { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}