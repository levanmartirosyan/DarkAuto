using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DarkAuto.Migrations
{
    /// <inheritdoc />
    public partial class Sixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Payments_PaymentId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Payments_PaymentId1",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_PaymentId1",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PaymentId1",
                table: "Cars");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Payments_PaymentId",
                table: "Cars",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Payments_PaymentId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId1",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PaymentId1",
                table: "Cars",
                column: "PaymentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Payments_PaymentId",
                table: "Cars",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Payments_PaymentId1",
                table: "Cars",
                column: "PaymentId1",
                principalTable: "Payments",
                principalColumn: "PaymentId");
        }
    }
}
