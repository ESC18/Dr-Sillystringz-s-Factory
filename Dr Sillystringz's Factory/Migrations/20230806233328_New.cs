using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dr_Sillystringz_s_Factory.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Machines",
                newName: "Manufacturer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Machines",
                newName: "MachineId");

            migrationBuilder.RenameColumn(
                name: "LicenseNumber",
                table: "Engineers",
                newName: "Specialty");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Engineers",
                newName: "EngineerId");

            migrationBuilder.AddColumn<DateTime>(
                name: "InstallationDate",
                table: "Machines",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstallationDate",
                table: "Machines");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "Machines",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "MachineId",
                table: "Machines",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Specialty",
                table: "Engineers",
                newName: "LicenseNumber");

            migrationBuilder.RenameColumn(
                name: "EngineerId",
                table: "Engineers",
                newName: "Id");
        }
    }
}
