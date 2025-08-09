using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pioneers.InfraStructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class PioneerStructuredb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employeeProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    DropListOptions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DropdownOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomPropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropdownOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DropdownOptions_employeeProperties_CustomPropertyId",
                        column: x => x.CustomPropertyId,
                        principalTable: "employeeProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePropertyValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CustomPropertyId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePropertyValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePropertyValues_employeeProperties_CustomPropertyId",
                        column: x => x.CustomPropertyId,
                        principalTable: "employeeProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeePropertyValues_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DropdownOptions_CustomPropertyId",
                table: "DropdownOptions",
                column: "CustomPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePropertyValues_CustomPropertyId",
                table: "EmployeePropertyValues",
                column: "CustomPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePropertyValues_EmployeeId",
                table: "EmployeePropertyValues",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DropdownOptions");

            migrationBuilder.DropTable(
                name: "EmployeePropertyValues");

            migrationBuilder.DropTable(
                name: "employeeProperties");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
