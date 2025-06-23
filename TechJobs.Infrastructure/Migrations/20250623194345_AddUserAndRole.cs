using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechJobs.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAndRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "JobSeeker" },
                    { 2, "Employer" },
                    { 3, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "FullName", "PasswordHash", "Phone", "RoleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 23, 19, 43, 44, 75, DateTimeKind.Utc).AddTicks(97), "kaziabu.sayeed29@gmail.com", "Kazi Abu Sayeed", "admin12345", "01681-186651", 3 },
                    { 2, new DateTime(2025, 6, 23, 19, 43, 44, 75, DateTimeKind.Utc).AddTicks(99), "Mahmudul Hasan@gmail.com", "Mahmudul Hasan", "mahmudul12345", "01711-000002", 1 },
                    { 3, new DateTime(2025, 6, 23, 19, 43, 44, 75, DateTimeKind.Utc).AddTicks(101), "jahangir.seeker@jobmail.com", "Jahangir Alam", "jahangir_hash", "01711-000003", 1 },
                    { 4, new DateTime(2025, 6, 23, 19, 43, 44, 75, DateTimeKind.Utc).AddTicks(103), "nasima.employer@employer.com", "Nasima Begum", "nasima_hash", "01711-000004", 2 },
                    { 5, new DateTime(2025, 6, 23, 19, 43, 44, 75, DateTimeKind.Utc).AddTicks(105), "abdur.employer@employer.com", "Abdur Rahman", "abdur_hash", "01711-000005", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
