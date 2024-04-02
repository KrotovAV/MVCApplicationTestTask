using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Inn = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    AdressUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdressFact = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeriaPassport = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    NumberPassport = table.Column<int>(type: "int", maxLength: 7, nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organization",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_OrganizationId",
                table: "employee",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "organization");
        }
    }
}
