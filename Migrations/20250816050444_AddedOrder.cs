using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodOrderingAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentMode",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderTrackings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMode = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderTrackings_OrderId",
                table: "OrderTrackings",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_InvoiceId",
                table: "Order",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTrackings_Order_OrderId",
                table: "OrderTrackings",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderTrackings_Order_OrderId",
                table: "OrderTrackings");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropIndex(
                name: "IX_OrderTrackings_OrderId",
                table: "OrderTrackings");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderTrackings");

            migrationBuilder.AddColumn<int>(
                name: "PaymentMode",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
