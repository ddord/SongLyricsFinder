using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.EFCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlbumInfos",
                columns: table => new
                {
                    AlbumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_AlbumInfos", x => x.AlbumId);
                });

            migrationBuilder.CreateTable(
                name: "LyricsInfos",
                columns: table => new
                {
                    SongId = table.Column<int>(nullable: false),
                    LyricsId = table.Column<int>(nullable: false),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumInfos");

            migrationBuilder.DropTable(
                name: "LyricsInfos");
        }
    }
}
