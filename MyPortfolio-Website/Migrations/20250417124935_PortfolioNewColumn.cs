using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio_Website.Migrations
{
    /// <inheritdoc />
    public partial class PortfolioNewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PortfolioUrl",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PortfolioUrl",
                table: "Portfolios");
        }
    }
}
