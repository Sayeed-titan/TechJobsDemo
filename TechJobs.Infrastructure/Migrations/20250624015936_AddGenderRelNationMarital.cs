using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechJobs.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGenderRelNationMarital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });
            migrationBuilder.CreateTable(
                name: "MaritalStatuses",
                columns: table => new
                {
                    MaritalStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaritalStatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatuses", x => x.MaritalStatusId);
                });
            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    NationalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.NationalityId);
                });
            migrationBuilder.CreateTable(
                name: "Religions",
                columns: table => new
                {
                    ReligionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReligionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religions", x => x.ReligionId);
                });
            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "GenderName" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" },
                    { 3, "Other" }
                });
            migrationBuilder.InsertData(
                table: "MaritalStatuses",
                columns: new[] { "MaritalStatusId", "MaritalStatusName" },
                values: new object[,]
                {
                    { 1, "Single" },
                    { 2, "Married" },
                    { 3, "Divorced" },
                    { 4, "Widowed" }
                });
            migrationBuilder.InsertData(
                table: "Nationalities",
                columns: new[] { "NationalityId", "NationalityName" },
                values: new object[,]
                {
                    { 1, "Bangladeshi" },
                    { 2, "Indian" },
                    { 3, "Pakistani" },
                    { 4, "Nepali" },
                    { 5, "Other" }
                });
            migrationBuilder.InsertData(
                table: "Religions",
                columns: new[] { "ReligionId", "ReligionName" },
                values: new object[,]
                {
                    { 1, "Islam" },
                    { 2, "Christianity" },
                    { 3, "Hinduism" },
                    { 4, "Buddhism" },
                    { 5, "Other" }
                });

         #region Stored Procedure
            //Nationality
            migrationBuilder.Sql(@"
               CREATE PROCEDURE spNationalityCreate
                   @NationalityName NVARCHAR(50)
               AS
               BEGIN
                   INSERT INTO Nationalities (NationalityName)
                   VALUES (@NationalityName);
                   SELECT SCOPE_IDENTITY() AS NewNationalityId;
               END
               ");
            migrationBuilder.Sql(@"
               CREATE PROCEDURE spNationalityGetById
                   @NationalityId INT
               AS
               BEGIN
                   SELECT * FROM Nationalities
                   WHERE NationalityId = @NationalityId;
               END
               ");
            migrationBuilder.Sql(@"
               CREATE PROCEDURE spNationalityGetAll
               AS
               BEGIN
                   SELECT * FROM Nationalities;
               END
               ");
            migrationBuilder.Sql(@"
               CREATE PROCEDURE spNationalityUpdate
                   @NationalityId INT,
                   @NationalityName NVARCHAR(50)
               AS
               BEGIN
                   UPDATE Nationalities
                   SET NationalityName = @NationalityName
                   WHERE NationalityId = @NationalityId;
               END
               ");
            migrationBuilder.Sql(@"
               CREATE PROCEDURE spNationalityDelete
                   @NationalityId INT
               AS
               BEGIN
                   DELETE FROM Nationalities
                   WHERE NationalityId = @NationalityId;
               END
               ");
         #endregion

         migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 24, 1, 59, 35, 955, DateTimeKind.Utc).AddTicks(8917));
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 24, 1, 59, 35, 955, DateTimeKind.Utc).AddTicks(8920));
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 24, 1, 59, 35, 955, DateTimeKind.Utc).AddTicks(8922));
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 24, 1, 59, 35, 955, DateTimeKind.Utc).AddTicks(8924));
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 24, 1, 59, 35, 955, DateTimeKind.Utc).AddTicks(8927));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "MaritalStatuses");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "Religions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 19, 43, 44, 75, DateTimeKind.Utc).AddTicks(97));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 19, 43, 44, 75, DateTimeKind.Utc).AddTicks(99));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 19, 43, 44, 75, DateTimeKind.Utc).AddTicks(101));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 19, 43, 44, 75, DateTimeKind.Utc).AddTicks(103));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 23, 19, 43, 44, 75, DateTimeKind.Utc).AddTicks(105));

            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS spNationalityCreate");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS spNationalityGet");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS spNationalityGetAll");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS spNationalityUpdate");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS spNationalityDelete");



      }
    }
}
