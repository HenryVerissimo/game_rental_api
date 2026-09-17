using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameRentalApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletedAtColumnInRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Roles",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Roles");
        }
    }
}
