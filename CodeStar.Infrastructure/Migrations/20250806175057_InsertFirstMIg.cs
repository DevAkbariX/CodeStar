using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeStar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertFirstMIg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstructorProfileSummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasPriorExperience = table.Column<bool>(type: "bit", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessedByAdminId = table.Column<int>(type: "int", nullable: true),
                    ProcessedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    EmailConfirmationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailTokenExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FkRoleId = table.Column<int>(name: "Fk_RoleId", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Roles_Fk_RoleId",
                        column: x => x.FkRoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    EmailConfirmationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailTokenExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "InstructorMedia",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntroductionVideo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FkInstructorID = table.Column<long>(name: "Fk_InstructorID", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorMedia_Instructors_Fk_InstructorID",
                        column: x => x.FkInstructorID,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorCertification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKInstructorMediaID = table.Column<long>(name: "FK_InstructorMediaID", type: "bigint", nullable: false),
                    CertificateName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Issuer = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorCertification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorCertification_InstructorMedia_FK_InstructorMediaID",
                        column: x => x.FKInstructorMediaID,
                        principalTable: "InstructorMedia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorResume",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKInstructorMediaID = table.Column<long>(name: "FK_InstructorMediaID", type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorResume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorResume_InstructorMedia_FK_InstructorMediaID",
                        column: x => x.FKInstructorMediaID,
                        principalTable: "InstructorMedia",
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
                name: "IX_InstructorCertification_FK_InstructorMediaID",
                table: "InstructorCertification",
                column: "FK_InstructorMediaID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorMedia_Fk_InstructorID",
                table: "InstructorMedia",
                column: "Fk_InstructorID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorResume_FK_InstructorMediaID",
                table: "InstructorResume",
                column: "FK_InstructorMediaID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Fk_RoleId",
                table: "Instructors",
                column: "Fk_RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Fk_RoleId",
                table: "Users",
                column: "Fk_RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructorCertification");

            migrationBuilder.DropTable(
                name: "InstructorResume");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "InstructorMedia");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
