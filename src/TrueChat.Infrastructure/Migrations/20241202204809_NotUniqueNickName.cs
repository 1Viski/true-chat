using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrueChat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NotUniqueNickName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_Nickname",
                table: "ChatMessages");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_Nickname",
                table: "ChatMessages",
                column: "Nickname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ChatMessages_Nickname",
                table: "ChatMessages");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_Nickname",
                table: "ChatMessages",
                column: "Nickname",
                unique: true,
                filter: "[Nickname] IS NOT NULL");
        }
    }
}
