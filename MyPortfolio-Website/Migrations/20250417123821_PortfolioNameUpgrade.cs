using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio_Website.Migrations
{
    /// <inheritdoc />
    public partial class PortfolioNameUpgrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PortfolioImageUrl",
                table: "Portfolios",
                newName: "PortfolioImage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PortfolioImage",
                table: "Portfolios",
                newName: "PortfolioImageUrl");
        }
    }
}
