using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeStar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertSkillSparkTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkillSpark",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillProf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    View = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LikesCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isvalid = table.Column<bool>(type: "bit", nullable: false),
                    InstructorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSpark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillSpark_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillEpisode",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillSparkId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    EpisodeNumber = table.Column<int>(type: "int", nullable: false),
                    DurationInMinutes = table.Column<int>(type: "int", nullable: false),
                    VideoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillEpisode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillEpisode_SkillSpark_SkillSparkId",
                        column: x => x.SkillSparkId,
                        principalTable: "SkillSpark",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillQuestion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillSparkId = table.Column<long>(type: "bigint", nullable: false),
                    ParentQuestionId = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    isvalid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillQuestion_SkillQuestion_ParentQuestionId",
                        column: x => x.ParentQuestionId,
                        principalTable: "SkillQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SkillQuestion_SkillSpark_SkillSparkId",
                        column: x => x.SkillSparkId,
                        principalTable: "SkillSpark",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "skillSparkTags",
                columns: table => new
                {
                    SkillSparkId = table.Column<long>(type: "bigint", nullable: false),
                    TagId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skillSparkTags", x => new { x.SkillSparkId, x.TagId });
                    table.ForeignKey(
                        name: "FK_skillSparkTags_SkillSpark_SkillSparkId",
                        column: x => x.SkillSparkId,
                        principalTable: "SkillSpark",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skillSparkTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillEpisode_SkillSparkId",
                table: "SkillEpisode",
                column: "SkillSparkId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillQuestion_ParentQuestionId",
                table: "SkillQuestion",
                column: "ParentQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillQuestion_SkillSparkId",
                table: "SkillQuestion",
                column: "SkillSparkId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSpark_InstructorId",
                table: "SkillSpark",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_skillSparkTags_TagId",
                table: "skillSparkTags",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillEpisode");

            migrationBuilder.DropTable(
                name: "SkillQuestion");

            migrationBuilder.DropTable(
                name: "skillSparkTags");

            migrationBuilder.DropTable(
                name: "SkillSpark");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
