using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eComMaster.Migrations
{
    public partial class Add_Payment_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PAYMENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ORDER_ID = table.Column<int>(type: "int", nullable: false),
                    TRANSACTION_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PAYMENT_CODE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PAYMENT_STATUS = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PAYMENT_ID);
                    table.ForeignKey(
                        name: "FK_Payment_Order_ORDER_ID",
                        column: x => x.ORDER_ID,
                        principalTable: "Order",
                        principalColumn: "ORDER_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ORDER_ID",
                table: "Payment",
                column: "ORDER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
