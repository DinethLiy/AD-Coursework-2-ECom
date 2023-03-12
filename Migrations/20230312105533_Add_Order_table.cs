using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eComMaster.Migrations
{
    public partial class Add_Order_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ORDER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PC_MODEL_ID = table.Column<int>(type: "int", nullable: false),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    ORDER_AMOUNT = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ORDER_STATUS = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ORDER_ID);
                    table.ForeignKey(
                        name: "FK_Order_AuthUser_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_AuthUser_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                    table.ForeignKey(
                        name: "FK_Order_AuthUser_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                    table.ForeignKey(
                        name: "FK_Order_Customer_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "Customer",
                        principalColumn: "CUSTOMER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_PcModel_PC_MODEL_ID",
                        column: x => x.PC_MODEL_ID,
                        principalTable: "PcModel",
                        principalColumn: "PC_MODEL_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CreatedBy",
                table: "Order",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CUSTOMER_ID",
                table: "Order",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeletedBy",
                table: "Order",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ModifiedBy",
                table: "Order",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PC_MODEL_ID",
                table: "Order",
                column: "PC_MODEL_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
