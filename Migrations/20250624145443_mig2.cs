using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DarkAuto.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Cars_CardId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_DeliveryCompanies_DeliveryCompanyCompanyId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Users_UserId1",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Deliveries_DeliveryId1",
                table: "Payments");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryId1",
                table: "Payments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UserId1",
                table: "Deliveries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TrackingNumber",
                table: "Deliveries",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryCompanyCompanyId",
                table: "Deliveries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CardId",
                table: "Deliveries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "BidAmount",
                table: "Bids",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Cars_CardId",
                table: "Deliveries",
                column: "CardId",
                principalTable: "Cars",
                principalColumn: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_DeliveryCompanies_DeliveryCompanyCompanyId",
                table: "Deliveries",
                column: "DeliveryCompanyCompanyId",
                principalTable: "DeliveryCompanies",
                principalColumn: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Users_UserId1",
                table: "Deliveries",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Deliveries_DeliveryId1",
                table: "Payments",
                column: "DeliveryId1",
                principalTable: "Deliveries",
                principalColumn: "DeliveryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Cars_CardId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_DeliveryCompanies_DeliveryCompanyCompanyId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Users_UserId1",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Deliveries_DeliveryId1",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "BidAmount",
                table: "Bids");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryId1",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId1",
                table: "Deliveries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TrackingNumber",
                table: "Deliveries",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryCompanyCompanyId",
                table: "Deliveries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CardId",
                table: "Deliveries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Cars_CardId",
                table: "Deliveries",
                column: "CardId",
                principalTable: "Cars",
                principalColumn: "CardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_DeliveryCompanies_DeliveryCompanyCompanyId",
                table: "Deliveries",
                column: "DeliveryCompanyCompanyId",
                principalTable: "DeliveryCompanies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Users_UserId1",
                table: "Deliveries",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Deliveries_DeliveryId1",
                table: "Payments",
                column: "DeliveryId1",
                principalTable: "Deliveries",
                principalColumn: "DeliveryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
