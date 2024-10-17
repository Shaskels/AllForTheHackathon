using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllForTheHackathon.Migrations
{
    /// <inheritdoc />
    public partial class MToM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Wishlist_WishlistId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_WishlistId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WishlistId",
                table: "Employees");

            migrationBuilder.CreateTable(
                name: "dlsa;ld;a",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "INTEGER", nullable: false),
                    WishlistsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dlsa;ld;a", x => new { x.EmployeesId, x.WishlistsId });
                    table.ForeignKey(
                        name: "FK_dlsa;ld;a_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dlsa;ld;a_Wishlist_WishlistsId",
                        column: x => x.WishlistsId,
                        principalTable: "Wishlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dlsa;ld;a_WishlistsId",
                table: "dlsa;ld;a",
                column: "WishlistsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dlsa;ld;a");

            migrationBuilder.AddColumn<int>(
                name: "WishlistId",
                table: "Employees",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WishlistId",
                table: "Employees",
                column: "WishlistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Wishlist_WishlistId",
                table: "Employees",
                column: "WishlistId",
                principalTable: "Wishlist",
                principalColumn: "Id");
        }
    }
}
