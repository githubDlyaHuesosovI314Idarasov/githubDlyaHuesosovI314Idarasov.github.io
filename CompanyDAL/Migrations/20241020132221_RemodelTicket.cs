using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyDAL.Migrations
{
    /// <inheritdoc />
    public partial class RemodelTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "To",
                table: "Tickets",
                newName: "CountryTo");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "Tickets",
                newName: "CountryFrom");

            migrationBuilder.RenameColumn(
                name: "To",
                table: "Planes",
                newName: "CountryTo");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "Planes",
                newName: "CountryFrom");

            migrationBuilder.AddColumn<string>(
                name: "CityFrom",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityTo",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityFrom",
                table: "Planes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityTo",
                table: "Planes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CityFrom", "CityTo", "CountryFrom" },
                values: new object[] { "DonbASS", "Warsaw", "Ukraine" });

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CityFrom", "CityTo", "CountryFrom", "CountryTo" },
                values: new object[] { "DonbASS", "Warsaw", "Ukraine", "Poland" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityFrom",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CityTo",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CityFrom",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "CityTo",
                table: "Planes");

            migrationBuilder.RenameColumn(
                name: "CountryTo",
                table: "Tickets",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "CountryFrom",
                table: "Tickets",
                newName: "From");

            migrationBuilder.RenameColumn(
                name: "CountryTo",
                table: "Planes",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "CountryFrom",
                table: "Planes",
                newName: "From");

            migrationBuilder.UpdateData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 1,
                column: "From",
                value: "DonbASS");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "From", "To" },
                values: new object[] { "DonbASS", "Warsaw" });
        }
    }
}
