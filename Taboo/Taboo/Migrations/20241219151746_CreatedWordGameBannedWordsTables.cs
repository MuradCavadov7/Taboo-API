using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Taboo.Migrations
{
    /// <inheritdoc />
    public partial class CreatedWordGameBannedWordsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BannedWordCount = table.Column<int>(type: "int", nullable: false),
                    FailCount = table.Column<int>(type: "int", nullable: false),
                    SkipCount = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    SuccessAnswer = table.Column<int>(type: "int", nullable: false),
                    WrongAnswer = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Languages_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_Languages_LanguageCode",
                        column: x => x.LanguageCode,
                        principalTable: "Languages",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BannedWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    WordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannedWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BannedWords_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Code", "Icon", "Name" },
                values: new object[,]
                {
                    { "AZ", "https://upload.wikimedia.org/wikipedia/commons/3/3d/AZ-Azerbaijan-Flag-icon.png", "Azərbaycan" },
                    { "EN", "https://cdn-icons-png.flaticon.com/512/5111/5111640.png", "English" },
                    { "RU", "https://icons.iconarchive.com/icons/custom-icon-design/flat-europe-flag/256/Russia-icon.png", "Русский" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Name",
                table: "Languages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BannedWords_WordId",
                table: "BannedWords",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_LanguageCode",
                table: "Games",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Words_LanguageCode",
                table: "Words",
                column: "LanguageCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BannedWords");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Languages_Name",
                table: "Languages");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Code",
                keyValue: "AZ");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Code",
                keyValue: "EN");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Code",
                keyValue: "RU");
        }
    }
}
