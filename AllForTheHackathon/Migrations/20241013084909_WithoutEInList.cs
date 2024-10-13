using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllForTheHackathon.Migrations
{
    /// <inheritdoc />
    public partial class WithoutEInList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesInWishlists");

            migrationBuilder.DropIndex(
                name: "IX_Wishlist_EmployeeId",
                table: "Wishlist");

            migrationBuilder.AlterColumn<double>(
                name: "Result",
                table: "Hackathons",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "WishlistId",
                table: "Employees",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_EmployeeId",
                table: "Wishlist",
                column: "EmployeeId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Wishlist_WishlistId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Wishlist_EmployeeId",
                table: "Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_Employees_WishlistId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WishlistId",
                table: "Employees");

            migrationBuilder.AlterColumn<decimal>(
                name: "Result",
                table: "Hackathons",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.CreateTable(
                name: "EmployeesInWishlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    WishlistId = table.Column<int>(type: "INTEGER", nullable: false),
                    PositionInList = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesInWishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeesInWishlists_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesInWishlists_Wishlist_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_EmployeeId",
                table: "Wishlist",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesInWishlists_EmployeeId",
                table: "EmployeesInWishlists",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesInWishlists_WishlistId",
                table: "EmployeesInWishlists",
                column: "WishlistId");
        }
    }
}
