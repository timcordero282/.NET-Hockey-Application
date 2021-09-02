using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HockeyProject.Migrations
{
    public partial class HockeyProj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    CoachID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoachName = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    CareerWins = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.CoachID);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(nullable: false),
                    Position = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Goals = table.Column<int>(nullable: false),
                    Assists = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(nullable: false),
                    Conference = table.Column<string>(nullable: false),
                    Wins = table.Column<int>(nullable: false),
                    Losses = table.Column<int>(nullable: false),
                    PlayerID = table.Column<int>(nullable: false),
                    CoachID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Teams_Coaches_CoachID",
                        column: x => x.CoachID,
                        principalTable: "Coaches",
                        principalColumn: "CoachID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teams_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "CoachID", "CareerWins", "CoachName", "Country", "DateOfBirth" },
                values: new object[,]
                {
                    { 1, 689, "Alain Vigneault", "Canada", new DateTime(1961, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 284, "Mike Sullivan", "US", new DateTime(1968, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerID", "Assists", "Country", "DateOfBirth", "Goals", "PlayerName", "Position" },
                values: new object[,]
                {
                    { 1, 32, "Canada", new DateTime(1988, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, "Claude Giroux", "Center" },
                    { 2, 31, "Canada", new DateTime(1987, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "Sidney Crosby", "Center" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamID", "CoachID", "Conference", "Losses", "PlayerID", "TeamName", "Wins" },
                values: new object[] { 1, 1, "Eastern", 21, 1, "Philadelphia Flyers", 41 });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamID", "CoachID", "Conference", "Losses", "PlayerID", "TeamName", "Wins" },
                values: new object[] { 2, 2, "Eastern", 23, 2, "Pittsburgh Penguins", 40 });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CoachID",
                table: "Teams",
                column: "CoachID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PlayerID",
                table: "Teams",
                column: "PlayerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
