using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenamePricingPlanToRentalPeriod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the existing foreign key constraint
            migrationBuilder.DropForeignKey(
                name: "FK_CarReservationPricings_PricingPlans_PricingPlanId",
                table: "CarReservationPricings"
            );

            // Rename table from PricingPlans to RentalPeriods
            migrationBuilder.RenameTable(
                name: "PricingPlans",
                newName: "RentalPeriods"
            );

            // Rename column in CarReservationPricings table
            migrationBuilder.RenameColumn(
                name: "PricingPlanId",
                table: "CarReservationPricings",
                newName: "RentalPeriodId"
            );

            // Rename index in CarReservationPricings table
            migrationBuilder.RenameIndex(
                name: "IX_CarReservationPricings_PricingPlanId",
                table: "CarReservationPricings",
                newName: "IX_CarReservationPricings_RentalPeriodId"
            );

            // Re-add foreign key constraint with the new table name
            migrationBuilder.AddForeignKey(
                name: "FK_CarReservationPricings_RentalPeriods_RentalPeriodId",
                table: "CarReservationPricings",
                column: "RentalPeriodId",
                principalTable: "RentalPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the updated foreign key constraint
            migrationBuilder.DropForeignKey(
                name: "FK_CarReservationPricings_RentalPeriods_RentalPeriodId",
                table: "CarReservationPricings"
            );

            // Rename table back to PricingPlans
            migrationBuilder.RenameTable(
                name: "RentalPeriods",
                newName: "PricingPlans"
            );

            // Rename column back in CarReservationPricings table
            migrationBuilder.RenameColumn(
                name: "RentalPeriodId",
                table: "CarReservationPricings",
                newName: "PricingPlanId"
            );

            // Rename index back in CarReservationPricings table
            migrationBuilder.RenameIndex(
                name: "IX_CarReservationPricings_RentalPeriodId",
                table: "CarReservationPricings",
                newName: "IX_CarReservationPricings_PricingPlanId"
            );

            // Re-add foreign key constraint with the original table name
            migrationBuilder.AddForeignKey(
                name: "FK_CarReservationPricings_PricingPlans_PricingPlanId",
                table: "CarReservationPricings",
                column: "PricingPlanId",
                principalTable: "PricingPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }
    }
}
