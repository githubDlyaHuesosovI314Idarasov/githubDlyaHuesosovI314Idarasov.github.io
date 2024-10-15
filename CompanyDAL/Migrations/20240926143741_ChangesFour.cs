using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyDAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangesFour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_PassengerId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Passengers");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassengerId",
                table: "Tickets",
                column: "PassengerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_PassengerId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Passengers",
                keyColumn: "Id",
                keyValue: 1,
                column: "TicketId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassengerId",
                table: "Tickets",
                column: "PassengerId",
                unique: true);
        }
    }
}
