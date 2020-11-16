using Microsoft.EntityFrameworkCore.Migrations;

namespace DiaBet.Data.Migrations
{
    public partial class AddedGameRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Odds_OddsId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Results_ResultId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Results_GameId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Odds_GameId",
                table: "Odds");

            migrationBuilder.DropIndex(
                name: "IX_Games_OddsId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ResultId",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "ResultId",
                table: "Games",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OddsId",
                table: "Games",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_GameId",
                table: "Results",
                column: "GameId",
                unique: true,
                filter: "[GameId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Odds_GameId",
                table: "Odds",
                column: "GameId",
                unique: true,
                filter: "[GameId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Results_GameId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Odds_GameId",
                table: "Odds");

            migrationBuilder.AlterColumn<string>(
                name: "ResultId",
                table: "Games",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OddsId",
                table: "Games",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_GameId",
                table: "Results",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Odds_GameId",
                table: "Odds",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_OddsId",
                table: "Games",
                column: "OddsId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_ResultId",
                table: "Games",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Odds_OddsId",
                table: "Games",
                column: "OddsId",
                principalTable: "Odds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Results_ResultId",
                table: "Games",
                column: "ResultId",
                principalTable: "Results",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
