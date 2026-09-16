using GameRentalApi.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameRentalApi.Infrastructure.Data.Configurations;


public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(user => user.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(user => user.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(user => user.PasswordHash)
            .IsRequired()
            .HasMaxLength(350);

        builder.Property(user => user.PhoneNumber)
            .IsRequired()
            .HasMaxLength(15);

        builder.HasMany(user => user.Rentals)
            .WithOne(rental => rental.User)
            .HasForeignKey(rental => rental.UserId);
    }
}