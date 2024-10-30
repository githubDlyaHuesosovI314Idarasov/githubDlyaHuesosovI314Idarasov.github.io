using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyDAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangingToDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TimeFrom",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TimeTo",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "TimeFrom",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "TimeTo",
                table: "Planes");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeFrom",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeTo",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeFrom",
                table: "Planes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeTo",
                table: "Planes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateTimeFrom", "DateTimeTo" },
                values: new object[] { new DateTime(420, 4, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 9, 11, 23, 59, 59, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateTimeFrom", "DateTimeTo" },
                values: new object[] { new DateTime(420, 4, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 9, 11, 23, 59, 59, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTimeFrom",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DateTimeTo",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "DateTimeFrom",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "DateTimeTo",
                table: "Planes");

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

            migrationBuilder.AddColumn<TimeOnly>(
                name: "TimeFrom",
                table: "Tickets",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "TimeTo",
                table: "Tickets",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

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

            migrationBuilder.AddColumn<TimeOnly>(
                name: "TimeFrom",
                table: "Planes",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "TimeTo",
                table: "Planes",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo", "TimeFrom", "TimeTo" },
                values: new object[] { new DateOnly(420, 4, 20), new DateOnly(2001, 9, 11), new TimeOnly(20, 30, 0), new TimeOnly(8, 30, 0) });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo", "TimeFrom", "TimeTo" },
                values: new object[] { new DateOnly(420, 4, 20), new DateOnly(2001, 9, 11), new TimeOnly(20, 30, 0), new TimeOnly(8, 30, 0) });
        }
    }
}
