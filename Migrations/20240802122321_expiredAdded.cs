using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppleAccounts.Migrations
{
    /// <inheritdoc />
    public partial class expiredAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Expired",
                table: "AppleIds",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expired",
                table: "AppleIds");
        }
    }
}
