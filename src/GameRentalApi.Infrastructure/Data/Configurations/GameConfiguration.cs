using GameRentalApi.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameRentalApi.Infrastructure.Data.Configurations;


public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(game => game.Id);

        builder.Property(game => game.Title)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(game => game.Description)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(game => game.Price)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(game => game.GameCoverImageUrl)
            .HasMaxLength(350);

        builder.HasOne(game => game.VideoGame)
            .WithMany(videoGame => videoGame.Games)
            .HasForeignKey(VideoGame => VideoGame.VideoGameId);
    }
}