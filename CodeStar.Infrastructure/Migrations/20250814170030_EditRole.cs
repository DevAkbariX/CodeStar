using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeStar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_skillSparkTags_SkillSpark_SkillSparkId",
                table: "skillSparkTags");

            migrationBuilder.DropForeignKey(
                name: "FK_skillSparkTags_Tags_TagId",
                table: "skillSparkTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_skillSparkTags",
                table: "skillSparkTags");

            migrationBuilder.RenameTable(
                name: "skillSparkTags",
                newName: "SkillSparkTags");

            migrationBuilder.RenameIndex(
                name: "IX_skillSparkTags_TagId",
                table: "SkillSparkTags",
                newName: "IX_SkillSparkTags_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SkillSparkTags",
                table: "SkillSparkTags",
                columns: new[] { "SkillSparkId", "TagId" });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    FkPermissionId = table.Column<int>(name: "Fk_PermissionId", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.FkPermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_Fk_PermissionId",
                        column: x => x.FkPermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_Fk_PermissionId",
                table: "RolePermissions",
                column: "Fk_PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSparkTags_SkillSpark_SkillSparkId",
                table: "SkillSparkTags",
                column: "SkillSparkId",
                principalTable: "SkillSpark",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSparkTags_Tags_TagId",
                table: "SkillSparkTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillSparkTags_SkillSpark_SkillSparkId",
                table: "SkillSparkTags");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillSparkTags_Tags_TagId",
                table: "SkillSparkTags");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SkillSparkTags",
                table: "SkillSparkTags");

            migrationBuilder.RenameTable(
                name: "SkillSparkTags",
                newName: "skillSparkTags");

            migrationBuilder.RenameIndex(
                name: "IX_SkillSparkTags_TagId",
                table: "skillSparkTags",
                newName: "IX_skillSparkTags_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_skillSparkTags",
                table: "skillSparkTags",
                columns: new[] { "SkillSparkId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_skillSparkTags_SkillSpark_SkillSparkId",
                table: "skillSparkTags",
                column: "SkillSparkId",
                principalTable: "SkillSpark",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_skillSparkTags_Tags_TagId",
                table: "skillSparkTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
