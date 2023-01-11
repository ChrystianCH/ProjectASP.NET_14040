using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectASP.NET14040.Migrations
{
    /// <inheritdoc />
    public partial class BookStoresLogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CinemaLogo",
                table: "BookStores",
                newName: "BookStoreLogo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookStoreLogo",
                table: "BookStores",
                newName: "CinemaLogo");
        }
    }
}
