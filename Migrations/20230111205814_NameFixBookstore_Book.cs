using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectASP.NET14040.Migrations
{
    /// <inheritdoc />
    public partial class NameFixBookstoreBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookStore_Book_BookStores_BookStoreId",
                table: "BookStore_Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BookStore_Book_Books_BookId",
                table: "BookStore_Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookStore_Book",
                table: "BookStore_Book");

            migrationBuilder.RenameTable(
                name: "BookStore_Book",
                newName: "BookStores_Books");

            migrationBuilder.RenameIndex(
                name: "IX_BookStore_Book_BookStoreId",
                table: "BookStores_Books",
                newName: "IX_BookStores_Books_BookStoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookStores_Books",
                table: "BookStores_Books",
                columns: new[] { "BookId", "BookStoreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookStores_Books_BookStores_BookStoreId",
                table: "BookStores_Books",
                column: "BookStoreId",
                principalTable: "BookStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookStores_Books_Books_BookId",
                table: "BookStores_Books",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookStores_Books_BookStores_BookStoreId",
                table: "BookStores_Books");

            migrationBuilder.DropForeignKey(
                name: "FK_BookStores_Books_Books_BookId",
                table: "BookStores_Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookStores_Books",
                table: "BookStores_Books");

            migrationBuilder.RenameTable(
                name: "BookStores_Books",
                newName: "BookStore_Book");

            migrationBuilder.RenameIndex(
                name: "IX_BookStores_Books_BookStoreId",
                table: "BookStore_Book",
                newName: "IX_BookStore_Book_BookStoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookStore_Book",
                table: "BookStore_Book",
                columns: new[] { "BookId", "BookStoreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookStore_Book_BookStores_BookStoreId",
                table: "BookStore_Book",
                column: "BookStoreId",
                principalTable: "BookStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookStore_Book_Books_BookId",
                table: "BookStore_Book",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
