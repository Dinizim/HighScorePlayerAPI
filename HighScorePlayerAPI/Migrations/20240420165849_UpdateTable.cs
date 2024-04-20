using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighScorePlayerAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "Player_Name",
                table: "Players",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Players",
                newName: "Player_Id");

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Game_Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Game_Id);
                });

            migrationBuilder.CreateTable(
                name: "HighScores",
                columns: table => new
                {
                    HighScoreId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    GameId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighScores", x => x.HighScoreId);
                    table.ForeignKey(
                        name: "FK_HighScores_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Game_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HighScores_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Player_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HighScores_GameId",
                table: "HighScores",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_HighScores_PlayerId",
                table: "HighScores",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HighScores");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Players",
                newName: "Player_Name");

            migrationBuilder.RenameColumn(
                name: "Player_Id",
                table: "Players",
                newName: "Id");

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "Players",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
