using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameCarReservationPricingReservationPricingToPricingPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarReservationPricings_PricingPlans_ReservationPricingId",
                table: "CarReservationPricings");

            migrationBuilder.RenameColumn(
                name: "ReservationPricingId",
                table: "CarReservationPricings",
                newName: "PricingPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_CarReservationPricings_ReservationPricingId",
                table: "CarReservationPricings",
                newName: "IX_CarReservationPricings_PricingPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarReservationPricings_PricingPlans_PricingPlanId",
                table: "CarReservationPricings",
                column: "PricingPlanId",
                principalTable: "PricingPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarReservationPricings_PricingPlans_PricingPlanId",
                table: "CarReservationPricings");

            migrationBuilder.RenameColumn(
                name: "PricingPlanId",
                table: "CarReservationPricings",
                newName: "ReservationPricingId");

            migrationBuilder.RenameIndex(
                name: "IX_CarReservationPricings_PricingPlanId",
                table: "CarReservationPricings",
                newName: "IX_CarReservationPricings_ReservationPricingId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarReservationPricings_PricingPlans_ReservationPricingId",
                table: "CarReservationPricings",
                column: "ReservationPricingId",
                principalTable: "PricingPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
