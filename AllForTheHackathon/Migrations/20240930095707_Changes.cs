using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AllForTheHackathon.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Junior_JuniorId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_TeamLead_TeamLeaderId",
                table: "Team");

            migrationBuilder.AddColumn<int>(
                name: "IdInList",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Employees_JuniorId",
                table: "Team",
                column: "JuniorId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Employees_TeamLeaderId",
                table: "Team",
                column: "TeamLeaderId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Employees_JuniorId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Employees_TeamLeaderId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "IdInList",
                table: "Employees");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Junior_JuniorId",
                table: "Team",
                column: "JuniorId",
                principalTable: "Junior",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_TeamLead_TeamLeaderId",
                table: "Team",
                column: "TeamLeaderId",
                principalTable: "TeamLead",
                principalColumn: "Id");
        }
    }
}
