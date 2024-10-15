using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyDAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangesTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Accounts_AccountId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Planes_PlaneId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Persons_PassengerId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Passengers");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_PlaneId",
                table: "Passengers",
                newName: "IX_Passengers_PlaneId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_AccountId",
                table: "Passengers",
                newName: "IX_Passengers_AccountId");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Accounts_AccountId",
                table: "Passengers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_Planes_PlaneId",
                table: "Passengers",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Passengers_PassengerId",
                table: "Tickets",
                column: "PassengerId",
                principalTable: "Passengers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Accounts_AccountId",
                table: "Passengers");

            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_Planes_PlaneId",
                table: "Passengers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Passengers_PassengerId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.RenameTable(
                name: "Passengers",
                newName: "Persons");

            migrationBuilder.RenameIndex(
                name: "IX_Passengers_PlaneId",
                table: "Persons",
                newName: "IX_Persons_PlaneId");

            migrationBuilder.RenameIndex(
                name: "IX_Passengers_AccountId",
                table: "Persons",
                newName: "IX_Persons_AccountId");

            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Accounts_AccountId",
                table: "Persons",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Planes_PlaneId",
                table: "Persons",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Persons_PassengerId",
                table: "Tickets",
                column: "PassengerId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
