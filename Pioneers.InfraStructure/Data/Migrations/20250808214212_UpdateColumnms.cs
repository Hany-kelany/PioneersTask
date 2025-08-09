using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pioneers.InfraStructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DropdownOptions_employeeProperties_CustomPropertyId",
                table: "DropdownOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePropertyValues_employeeProperties_CustomPropertyId",
                table: "EmployeePropertyValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employeeProperties",
                table: "employeeProperties");

            migrationBuilder.RenameTable(
                name: "employeeProperties",
                newName: "customProperty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customProperty",
                table: "customProperty",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DropdownOptions_customProperty_CustomPropertyId",
                table: "DropdownOptions",
                column: "CustomPropertyId",
                principalTable: "customProperty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePropertyValues_customProperty_CustomPropertyId",
                table: "EmployeePropertyValues",
                column: "CustomPropertyId",
                principalTable: "customProperty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DropdownOptions_customProperty_CustomPropertyId",
                table: "DropdownOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePropertyValues_customProperty_CustomPropertyId",
                table: "EmployeePropertyValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customProperty",
                table: "customProperty");

            migrationBuilder.RenameTable(
                name: "customProperty",
                newName: "employeeProperties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employeeProperties",
                table: "employeeProperties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DropdownOptions_employeeProperties_CustomPropertyId",
                table: "DropdownOptions",
                column: "CustomPropertyId",
                principalTable: "employeeProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePropertyValues_employeeProperties_CustomPropertyId",
                table: "EmployeePropertyValues",
                column: "CustomPropertyId",
                principalTable: "employeeProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
