using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DarkAuto.Migrations
{
    /// <inheritdoc />
    public partial class EighthFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Payments_PaymentId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_PaymentId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Cars");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PaymentId",
                table: "Cars",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Payments_PaymentId",
                table: "Cars",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId");
        }
    }
}
