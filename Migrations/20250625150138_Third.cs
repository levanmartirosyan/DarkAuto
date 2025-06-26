using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DarkAuto.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Cars_CarId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Cars_CarId1",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_DeliveryCompanies_DeliveryCompanyCompanyId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_DeliveryCompanies_DeliveryCompanyId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Users_UserId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Users_UserId1",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Deliveries_DeliveryId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_CarId1",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_DeliveryCompanyCompanyId",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_UserId1",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "CarId1",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "DeliveryCompanyCompanyId",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Deliveries");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Cars_CarId",
                table: "Deliveries",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_DeliveryCompanies_DeliveryCompanyId",
                table: "Deliveries",
                column: "DeliveryCompanyId",
                principalTable: "DeliveryCompanies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Users_UserId",
                table: "Deliveries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Deliveries_DeliveryId",
                table: "Payments",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "DeliveryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Cars_CarId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_DeliveryCompanies_DeliveryCompanyId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Users_UserId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Deliveries_DeliveryId",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "CarId1",
                table: "Deliveries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryCompanyCompanyId",
                table: "Deliveries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Deliveries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_CarId1",
                table: "Deliveries",
                column: "CarId1");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_DeliveryCompanyCompanyId",
                table: "Deliveries",
                column: "DeliveryCompanyCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_UserId1",
                table: "Deliveries",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Cars_CarId",
                table: "Deliveries",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Cars_CarId1",
                table: "Deliveries",
                column: "CarId1",
                principalTable: "Cars",
                principalColumn: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_DeliveryCompanies_DeliveryCompanyCompanyId",
                table: "Deliveries",
                column: "DeliveryCompanyCompanyId",
                principalTable: "DeliveryCompanies",
                principalColumn: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_DeliveryCompanies_DeliveryCompanyId",
                table: "Deliveries",
                column: "DeliveryCompanyId",
                principalTable: "DeliveryCompanies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Users_UserId",
                table: "Deliveries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Users_UserId1",
                table: "Deliveries",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Deliveries_DeliveryId",
                table: "Payments",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "DeliveryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
