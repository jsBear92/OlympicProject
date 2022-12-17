using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OlympicProject.Migrations
{
    public partial class Olympic1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(nullable: true),
                    UserPassword = table.Column<string>(nullable: true),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Competitor",
                columns: table => new
                {
                    CompetitorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitorSalutation = table.Column<string>(nullable: true),
                    CompetitorName = table.Column<string>(nullable: false),
                    CompetitorDoB = table.Column<DateTime>(nullable: false),
                    CompetitorEmail = table.Column<string>(nullable: false),
                    CompetitorDescription = table.Column<string>(nullable: true),
                    CompetitorCountry = table.Column<int>(nullable: false),
                    CompetitorGender = table.Column<int>(nullable: false),
                    CompetitorContactNo = table.Column<string>(nullable: true),
                    CompetitorWebsite = table.Column<string>(nullable: true),
                    CompetitorPhoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitor", x => x.CompetitorID);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameCode = table.Column<string>(maxLength: 7, nullable: true),
                    GameName = table.Column<string>(nullable: false),
                    GameDurationInHours = table.Column<string>(nullable: true),
                    GameDescription = table.Column<string>(nullable: true),
                    GameRulesBooklet = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameID = table.Column<int>(nullable: false),
                    FeatureEvent = table.Column<string>(nullable: true),
                    EventVenu = table.Column<string>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false),
                    EventStartTime = table.Column<DateTime>(nullable: false),
                    EventEndTime = table.Column<DateTime>(nullable: false),
                    EventDescription = table.Column<string>(nullable: false),
                    WorldRecord = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Event_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameCompetitor",
                columns: table => new
                {
                    GameID = table.Column<int>(nullable: false),
                    CompetitorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCompetitor", x => new { x.CompetitorID, x.GameID });
                    table.ForeignKey(
                        name: "FK_GameCompetitor_Competitor_CompetitorID",
                        column: x => x.CompetitorID,
                        principalTable: "Competitor",
                        principalColumn: "CompetitorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameCompetitor_Game_GameID",
                        column: x => x.GameID,
                        principalTable: "Game",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventPic",
                columns: table => new
                {
                    PhotoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventPhoto = table.Column<string>(nullable: true),
                    EventPhotoTags = table.Column<string>(nullable: true),
                    EventID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPic", x => x.PhotoID);
                    table.ForeignKey(
                        name: "FK_EventPic_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Podium",
                columns: table => new
                {
                    PodiumID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(nullable: false),
                    CompetitorID = table.Column<int>(nullable: false),
                    CompetitorPosition = table.Column<string>(nullable: true),
                    CompetitorMedal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podium", x => x.PodiumID);
                    table.ForeignKey(
                        name: "FK_Podium_Competitor_CompetitorID",
                        column: x => x.CompetitorID,
                        principalTable: "Competitor",
                        principalColumn: "CompetitorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Podium_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "UserID", "UserEmail", "UserPassword", "UserType" },
                values: new object[] { 1, "admin@ecu.com", "Admin#1", 0 });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "UserID", "UserEmail", "UserPassword", "UserType" },
                values: new object[] { 2, "event@ecu.com", "Event#1", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Event_GameID",
                table: "Event",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPic_EventID",
                table: "EventPic",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_GameCompetitor_GameID",
                table: "GameCompetitor",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Podium_CompetitorID",
                table: "Podium",
                column: "CompetitorID");

            migrationBuilder.CreateIndex(
                name: "IX_Podium_EventID",
                table: "Podium",
                column: "EventID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "EventPic");

            migrationBuilder.DropTable(
                name: "GameCompetitor");

            migrationBuilder.DropTable(
                name: "Podium");

            migrationBuilder.DropTable(
                name: "Competitor");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
