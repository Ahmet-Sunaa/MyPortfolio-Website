using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio_Website.Migrations
{
    /// <inheritdoc />
    public partial class protfolioUrlUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PortfolioWebUrl",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PortfolioWebUrl",
                table: "Portfolios");
        }
    }
}
