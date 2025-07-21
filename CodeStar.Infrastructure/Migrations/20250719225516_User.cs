using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeStar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherCertifications");

            migrationBuilder.DropTable(
                name: "TeacherResumes");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Profile = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FkRoleId = table.Column<int>(name: "Fk_RoleId", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_Fk_RoleId",
                        column: x => x.FkRoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Master",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntroductionVideo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FkUserId = table.Column<long>(name: "Fk_UserId", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Master_Users_Fk_UserId",
                        column: x => x.FkUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MasterCertifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKMasterId = table.Column<long>(name: "FK_MasterId", type: "bigint", nullable: false),
                    CertificateName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Issuer = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterCertifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterCertifications_Master_FK_MasterId",
                        column: x => x.FKMasterId,
                        principalTable: "Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterResumes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKMasterID = table.Column<long>(name: "FK_MasterID", type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterResumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterResumes_Master_FK_MasterID",
                        column: x => x.FKMasterID,
                        principalTable: "Master",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "IsActived", "PersionTitle", "Title" },
                values: new object[,]
                {
                    { 1, true, "مدیر سیستم", "Admin" },
                    { 2, true, "کاربر عادی", "User" },
                    { 3, true, "منتور راهنما", "Mentor" },
                    { 4, true, "مدرس دوره", "Teacher" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Master_Fk_UserId",
                table: "Master",
                column: "Fk_UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MasterCertifications_FK_MasterId",
                table: "MasterCertifications",
                column: "FK_MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterResumes_FK_MasterID",
                table: "MasterResumes",
                column: "FK_MasterID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Fk_RoleId",
                table: "Users",
                column: "Fk_RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterCertifications");

            migrationBuilder.DropTable(
                name: "MasterResumes");

            migrationBuilder.DropTable(
                name: "Master");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Git = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Linkdin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCertifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKTeacherID = table.Column<int>(name: "FK_TeacherID", type: "int", nullable: false),
                    CertificateName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Issuer = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCertifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherCertifications_Teachers_FK_TeacherID",
                        column: x => x.FKTeacherID,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherResumes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKTeacherID = table.Column<int>(name: "FK_TeacherID", type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherResumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherResumes_Teachers_FK_TeacherID",
                        column: x => x.FKTeacherID,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCertifications_FK_TeacherID",
                table: "TeacherCertifications",
                column: "FK_TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherResumes_FK_TeacherID",
                table: "TeacherResumes",
                column: "FK_TeacherID");
        }
    }
}
