using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DarkAuto.Migrations
{
    /// <inheritdoc />
    public partial class Eighth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Deliveries_DeliveryId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_DeliveryId",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Deliveries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_PaymentId",
                table: "Deliveries",
                column: "PaymentId",
                unique: true,
                filter: "[PaymentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Payments_PaymentId",
                table: "Deliveries",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Payments_PaymentId",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_PaymentId",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Deliveries");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_DeliveryId",
                table: "Payments",
                column: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Deliveries_DeliveryId",
                table: "Payments",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "DeliveryId");
        }
    }
}
