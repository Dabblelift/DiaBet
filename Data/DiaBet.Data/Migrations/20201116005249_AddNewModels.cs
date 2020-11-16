using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiaBet.Data.Migrations
{
    public partial class AddNewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Coins",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    FlagUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    League = table.Column<string>(maxLength: 50, nullable: true),
                    Stadium = table.Column<string>(maxLength: 30, nullable: true),
                    LogoUrl = table.Column<string>(nullable: true),
                    CountryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    GameId = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    BetType = table.Column<int>(nullable: false),
                    Prediction = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    BetOdds = table.Column<double>(nullable: false),
                    BetStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Odds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    GameId = table.Column<string>(nullable: true),
                    HomeWinOdds = table.Column<double>(nullable: false),
                    DrawOdds = table.Column<double>(nullable: false),
                    AwayWinOdds = table.Column<double>(nullable: false),
                    OverOdds = table.Column<double>(nullable: false),
                    UnderOdds = table.Column<double>(nullable: false),
                    BothTeamsToScoreOdds = table.Column<double>(nullable: false),
                    BothTeamsNotToScoreodds = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    GameId = table.Column<string>(nullable: true),
                    HomeTeamGoals = table.Column<int>(nullable: false),
                    AwayTeamGoals = table.Column<int>(nullable: false),
                    FullTimeResult = table.Column<int>(nullable: false),
                    MatchGoalsResult = table.Column<int>(nullable: false),
                    BothTeamsToScoreResult = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    HomeTeamId = table.Column<string>(nullable: true),
                    AwayTeamId = table.Column<string>(nullable: true),
                    ResultId = table.Column<string>(nullable: true),
                    OddsId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Odds_OddsId",
                        column: x => x.OddsId,
                        principalTable: "Odds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Results_ResultId",
                        column: x => x.ResultId,
                        principalTable: "Results",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_GameId",
                table: "Bets",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_UserId",
                table: "Bets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_AwayTeamId",
                table: "Games",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeTeamId",
                table: "Games",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_OddsId",
                table: "Games",
                column: "OddsId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ResultId",
                table: "Games",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Odds_GameId",
                table: "Odds",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_GameId",
                table: "Results",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CountryId",
                table: "Teams",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Games_GameId",
                table: "Bets",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Odds_Games_GameId",
                table: "Odds",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Games_GameId",
                table: "Results",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Odds_Games_GameId",
                table: "Odds");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Games_GameId",
                table: "Results");

            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Odds");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropColumn(
                name: "Coins",
                table: "AspNetUsers");
        }
    }
}
