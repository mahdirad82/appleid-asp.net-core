using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppleAccounts.Migrations
{
    /// <inheritdoc />
    public partial class thirdCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Locked",
                table: "AppleIds");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AppleIds",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "AppleIds");

            migrationBuilder.AddColumn<bool>(
                name: "Locked",
                table: "AppleIds",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
