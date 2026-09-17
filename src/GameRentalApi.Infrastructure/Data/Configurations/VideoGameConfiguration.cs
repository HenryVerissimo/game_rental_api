using GameRentalApi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameRentalApi.Infrastructure.Data.Configurations;


public class VideoGameConfiguration : IEntityTypeConfiguration<VideoGame>
{
    public void Configure(EntityTypeBuilder<VideoGame> builder)
    {
        builder.HasKey(videoGame => videoGame.Id);

        builder.Property(videoGame => videoGame.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(videoGame => videoGame.Company)
            .IsRequired()
            .HasMaxLength(100);
    }
}