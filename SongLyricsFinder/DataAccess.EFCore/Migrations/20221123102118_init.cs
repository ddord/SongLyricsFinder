using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.EFCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LyricsInfos",
                columns: table => new
                {
                    SongId = table.Column<int>(nullable: false),
                    LyricsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lyrics = table.Column<string>(nullable: true),
                    CreateUser = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LyricsInfos", x => new { x.SongId, x.LyricsId });
                });

            migrationBuilder.CreateTable(
                name: "SongInfos",
                columns: table => new
                {
                    SongId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Songname = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Artist = table.Column<string>(nullable: true),
                    Lyricist = table.Column<string>(nullable: true),
                    Composer = table.Column<string>(nullable: true),
                    CreateUser = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateUser = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongInfos", x => x.SongId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LyricsInfos");

            migrationBuilder.DropTable(
                name: "SongInfos");
        }
    }
}
