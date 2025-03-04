using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRentalCarAndReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Cars_CarId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CustomerFirstName",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CustomerLastName",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "CustomerDriverLicenseYear",
                table: "Reservations",
                newName: "RentalCarId");

            migrationBuilder.RenameColumn(
                name: "CustomerAge",
                table: "Reservations",
                newName: "CustomerId");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DropOffDate",
                table: "Reservations",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "PickUpDate",
                table: "Reservations",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RentalCarId",
                table: "Reservations",
                column: "RentalCarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_RentalCars_RentalCarId",
                table: "Reservations",
                column: "RentalCarId",
                principalTable: "RentalCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_RentalCars_RentalCarId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RentalCarId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DropOffDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PickUpDate",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "RentalCarId",
                table: "Reservations",
                newName: "CustomerDriverLicenseYear");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Reservations",
                newName: "CustomerAge");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerFirstName",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerLastName",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Cars_CarId",
                table: "Reservations",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
