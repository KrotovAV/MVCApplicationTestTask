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
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    inn = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    uriadress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    factadress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("organization_primary_key", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    surname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    secondname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    birthdata = table.Column<DateTime>(type: "date", nullable: false),
                    seriapass = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    numberpass = table.Column<int>(type: "int", maxLength: 7, nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employee_primary_key", x => x.Id);
                    table.ForeignKey(
                        name: "FK_employee_organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
