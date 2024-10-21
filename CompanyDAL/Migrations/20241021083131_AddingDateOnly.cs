using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingDateOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateFrom",
                table: "Tickets",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateTo",
                table: "Tickets",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateFrom",
                table: "Planes",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateTo",
                table: "Planes",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateOnly(420, 4, 20), new DateOnly(2001, 9, 11) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateOnly(420, 4, 20), new DateOnly(2001, 9, 11) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "Planes");
        }
    }
}
