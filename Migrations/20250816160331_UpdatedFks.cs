using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOrderingAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedFks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderTrackings_DeliveryAgents_DeliveryAgentId",
                table: "OrderTrackings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTrackings_Invoices_InvoiceId",
                table: "OrderTrackings");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTrackings_Orders_OrderId",
                table: "OrderTrackings");

            migrationBuilder.DropIndex(
                name: "IX_OrderTrackings_DeliveryAgentId",
                table: "OrderTrackings");

            migrationBuilder.DropIndex(
                name: "IX_OrderTrackings_InvoiceId",
                table: "OrderTrackings");

            migrationBuilder.DropColumn(
                name: "DeliveryAgentId",
                table: "OrderTrackings");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "OrderTrackings");

            migrationBuilder.AlterColumn<int>(
                name: "QuantityOrdered",
                table: "OrderTrackings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderTrackings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TotalAmount",
                table: "Invoices",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryAgentId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_DeliveryAgentId",
                table: "Invoices",
                column: "DeliveryAgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_DeliveryAgents_DeliveryAgentId",
                table: "Invoices",
                column: "DeliveryAgentId",
                principalTable: "DeliveryAgents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTrackings_Orders_OrderId",
                table: "OrderTrackings",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_DeliveryAgents_DeliveryAgentId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTrackings_Orders_OrderId",
                table: "OrderTrackings");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_DeliveryAgentId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "DeliveryAgentId",
                table: "Invoices");

            migrationBuilder.AlterColumn<int>(
                name: "QuantityOrdered",
                table: "OrderTrackings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "OrderTrackings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryAgentId",
                table: "OrderTrackings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "OrderTrackings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "TotalAmount",
                table: "Invoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderTrackings_DeliveryAgentId",
                table: "OrderTrackings",
                column: "DeliveryAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTrackings_InvoiceId",
                table: "OrderTrackings",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTrackings_DeliveryAgents_DeliveryAgentId",
                table: "OrderTrackings",
                column: "DeliveryAgentId",
                principalTable: "DeliveryAgents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTrackings_Invoices_InvoiceId",
                table: "OrderTrackings",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTrackings_Orders_OrderId",
                table: "OrderTrackings",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
