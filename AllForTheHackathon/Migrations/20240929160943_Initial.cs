using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllForTheHackathon.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hackathons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Result = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hackathons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    WishlistId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Wishlist_WishlistId",
                        column: x => x.WishlistId,
                        principalTable: "Wishlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Junior",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HackathonId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Junior", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Junior_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Junior_Hackathons_HackathonId",
                        column: x => x.HackathonId,
                        principalTable: "Hackathons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeamLead",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HackathonId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamLead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamLead_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamLead_Hackathons_HackathonId",
                        column: x => x.HackathonId,
                        principalTable: "Hackathons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JuniorId = table.Column<int>(type: "INTEGER", nullable: true),
                    SatisfactionOfJunior = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamLeaderId = table.Column<int>(type: "INTEGER", nullable: true),
                    SatisfactionOfTeamLeader = table.Column<int>(type: "INTEGER", nullable: false),
                    HackathonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Hackathons_HackathonId",
                        column: x => x.HackathonId,
                        principalTable: "Hackathons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Team_Junior_JuniorId",
                        column: x => x.JuniorId,
                        principalTable: "Junior",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Team_TeamLead_TeamLeaderId",
                        column: x => x.TeamLeaderId,
                        principalTable: "TeamLead",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WishlistId",
                table: "Employees",
                column: "WishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_Junior_HackathonId",
                table: "Junior",
                column: "HackathonId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_HackathonId",
                table: "Team",
                column: "HackathonId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_JuniorId",
                table: "Team",
                column: "JuniorId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_TeamLeaderId",
                table: "Team",
                column: "TeamLeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamLead_HackathonId",
                table: "TeamLead",
                column: "HackathonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Junior");

            migrationBuilder.DropTable(
                name: "TeamLead");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Hackathons");

            migrationBuilder.DropTable(
                name: "Wishlist");
        }
    }
}
