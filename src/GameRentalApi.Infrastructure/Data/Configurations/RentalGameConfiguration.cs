using GameRentalApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameRentalApi.Infrastructure.Data.Configurations;


public class RentalGameConfiguration : IEntityTypeConfiguration<RentalGame>
{
    public void Configure(EntityTypeBuilder<RentalGame> builder)
    {
        builder.HasKey(rentalGame => new { rentalGame.RentalId, rentalGame.GameId});

        builder.Property(rentalGame => rentalGame.UnitGamePrice)
            .HasPrecision(18, 2);

        builder.HasOne(rentalGame => rentalGame.Rental)
            .WithMany(rental => rental.RentalGames)
            .HasForeignKey(rentalGame => rentalGame.RentalId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(rentalGame => rentalGame.Game)
            .WithMany(game => game.RentalGames)
            .HasForeignKey(rentalGame => rentalGame.GameId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}