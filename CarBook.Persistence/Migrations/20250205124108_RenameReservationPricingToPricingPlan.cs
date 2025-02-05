using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameReservationPricingToPricingPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarReservationPricings_ReservationPricings_ReservationPricingId",
                table: "CarReservationPricings");

            migrationBuilder.DropTable(
                name: "ReservationPricings");

            migrationBuilder.CreateTable(
                name: "PricingPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricingPlans", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CarReservationPricings_PricingPlans_ReservationPricingId",
                table: "CarReservationPricings",
                column: "ReservationPricingId",
                principalTable: "PricingPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarReservationPricings_PricingPlans_ReservationPricingId",
                table: "CarReservationPricings");

            migrationBuilder.DropTable(
                name: "PricingPlans");

            migrationBuilder.CreateTable(
                name: "ReservationPricings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationPricings", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CarReservationPricings_ReservationPricings_ReservationPricingId",
                table: "CarReservationPricings",
                column: "ReservationPricingId",
                principalTable: "ReservationPricings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
