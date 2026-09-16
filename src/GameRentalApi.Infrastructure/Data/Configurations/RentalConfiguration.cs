using GameRentalApi.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameRentalApi.Infrastructure.Data.Configurations;


public class RentalConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure (EntityTypeBuilder<Rental> builder)
    {
        builder.HasKey(rental => rental.Id);

        builder.Property(rental => rental.TotalAmount)
            .HasPrecision(18, 2);

        builder.HasOne(rental => rental.User)
            .WithMany(user => user.Rentals)
            .HasForeignKey(rental => rental.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}