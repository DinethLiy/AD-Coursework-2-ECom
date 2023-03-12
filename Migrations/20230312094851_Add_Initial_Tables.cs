using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eComMaster.Migrations
{
    public partial class Add_Initial_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AuthUser = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DOB = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GENDER = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NIC = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ADDRESS = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CONTACT_NUM = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PENALTY_FEE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CUSTOMER_STATUS = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CUSTOMER_ID);
                    table.ForeignKey(
                        name: "FK_Customer_AuthUser_AuthUser",
                        column: x => x.AuthUser,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PcCategory",
                columns: table => new
                {
                    PC_CATEGORY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PC_CATEGORY_NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PC_CATEGORY_DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PC_CATEGORY_STATUS = table.Column<string>(type: "longtext", nullable: false)
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
                    table.PrimaryKey("PK_PcCategory", x => x.PC_CATEGORY_ID);
                    table.ForeignKey(
                        name: "FK_PcCategory_AuthUser_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PcCategory_AuthUser_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                    table.ForeignKey(
                        name: "FK_PcCategory_AuthUser_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PcSeries",
                columns: table => new
                {
                    PC_SERIES_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PcSeries = table.Column<int>(type: "int", nullable: false),
                    PC_SERIES_NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PC_SERIES_DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PC_SERIES_STATUS = table.Column<string>(type: "longtext", nullable: false)
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
                    table.PrimaryKey("PK_PcSeries", x => x.PC_SERIES_ID);
                    table.ForeignKey(
                        name: "FK_PcSeries_AuthUser_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PcSeries_AuthUser_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                    table.ForeignKey(
                        name: "FK_PcSeries_AuthUser_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                    table.ForeignKey(
                        name: "FK_PcSeries_PcCategory_PcSeries",
                        column: x => x.PcSeries,
                        principalTable: "PcCategory",
                        principalColumn: "PC_CATEGORY_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_AuthUser",
                table: "Customer",
                column: "AuthUser");

            migrationBuilder.CreateIndex(
                name: "IX_PcCategory_CreatedBy",
                table: "PcCategory",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PcCategory_DeletedBy",
                table: "PcCategory",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PcCategory_ModifiedBy",
                table: "PcCategory",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PcSeries_CreatedBy",
                table: "PcSeries",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PcSeries_DeletedBy",
                table: "PcSeries",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PcSeries_ModifiedBy",
                table: "PcSeries",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PcSeries_PcSeries",
                table: "PcSeries",
                column: "PcSeries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "PcSeries");

            migrationBuilder.DropTable(
                name: "PcCategory");
        }
    }
}
