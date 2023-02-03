using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class playlistfixv5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Users_CreatorUserID",
                table: "Playlists");

            migrationBuilder.RenameColumn(
                name: "CreatorUserID",
                table: "Playlists",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Playlists_CreatorUserID",
                table: "Playlists",
                newName: "IX_Playlists_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Users_UserId",
                table: "Playlists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Users_UserId",
                table: "Playlists");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Playlists",
                newName: "CreatorUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Playlists_UserId",
                table: "Playlists",
                newName: "IX_Playlists_CreatorUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Users_CreatorUserID",
                table: "Playlists",
                column: "CreatorUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
