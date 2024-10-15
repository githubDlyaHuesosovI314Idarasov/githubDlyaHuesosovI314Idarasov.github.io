using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyDAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangesThree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Planes_PlaneId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Passengers");

            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "Id", "From", "MaxPassengerCount", "Model", "TimeFrom", "TimeTo", "To" },
                values: new object[] { 1, "DonbASS", 911, "Boeing 767", new TimeOnly(20, 30, 0), new TimeOnly(8, 30, 0), "Warsaw" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "Name", "PlaneId", "SecondName", "Sex" },
                values: new object[] { 1, 20, "BaseEmployee", 1, "Second Name here", "Male" });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "Id", "Age", "Name", "PlaneId", "SecondName", "Sex", "TicketId" },
                values: new object[] { 1, 99, "BasePassenger", 1, "No", "Male", 1 });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "From", "PassengerId", "TimeFrom", "TimeTo", "To" },
                values: new object[] { 1, "DonbASS", 1, new TimeOnly(20, 30, 0), new TimeOnly(8, 30, 0), "Warsaw" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Planes_PlaneId",
                table: "Employees",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Planes_PlaneId",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Planes_PlaneId",
                table: "Employees",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "Id");
        }
    }
}
