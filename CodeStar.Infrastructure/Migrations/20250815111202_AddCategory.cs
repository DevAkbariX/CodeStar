using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeStar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SkillCategories",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkCategory = table.Column<int>(name: "Fk_Category", type: "int", nullable: false),
                    FkSkillSpark = table.Column<long>(name: "Fk_SkillSpark", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCategories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SkillCategories_Category_Fk_Category",
                        column: x => x.FkCategory,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillCategories_SkillSpark_Fk_SkillSpark",
                        column: x => x.FkSkillSpark,
                        principalTable: "SkillSpark",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillCategories_Fk_Category",
                table: "SkillCategories",
                column: "Fk_Category");

            migrationBuilder.CreateIndex(
                name: "IX_SkillCategories_Fk_SkillSpark",
                table: "SkillCategories",
                column: "Fk_SkillSpark");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillCategories");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
