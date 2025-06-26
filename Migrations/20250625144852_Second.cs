using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DarkAuto.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Deliveries_DeliveryId1",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_DeliveryId1",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "DeliveryId1",
                table: "Payments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryId1",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_DeliveryId1",
                table: "Payments",
                column: "DeliveryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Deliveries_DeliveryId1",
                table: "Payments",
                column: "DeliveryId1",
                principalTable: "Deliveries",
                principalColumn: "DeliveryId");
        }
    }
}
