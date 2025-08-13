using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeStar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelUserAndSkillQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SkillQuestion_UserId",
                table: "SkillQuestion",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillQuestion_Users_UserId",
                table: "SkillQuestion",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillQuestion_Users_UserId",
                table: "SkillQuestion");

            migrationBuilder.DropIndex(
                name: "IX_SkillQuestion_UserId",
                table: "SkillQuestion");
        }
    }
}
