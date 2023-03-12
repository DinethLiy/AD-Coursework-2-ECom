using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eComMaster.Migrations
{
    public partial class Add_PC_Model_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PcSeries_PcCategory_PcSeries",
                table: "PcSeries");

            migrationBuilder.RenameColumn(
                name: "PcSeries",
                table: "PcSeries",
                newName: "PcCategory");

            migrationBuilder.RenameIndex(
                name: "IX_PcSeries_PcSeries",
                table: "PcSeries",
                newName: "IX_PcSeries_PcCategory");

            migrationBuilder.CreateTable(
                name: "PcModel",
                columns: table => new
                {
                    PC_MODEL_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PcSeries = table.Column<int>(type: "int", nullable: false),
                    PC_MODEL_NAME = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PC_MODEL_DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MODEL_PRICE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    QUANTITY = table.Column<int>(type: "int", nullable: false),
                    Casing = table.Column<int>(type: "int", nullable: true),
                    Display = table.Column<int>(type: "int", nullable: true),
                    Graphics = table.Column<int>(type: "int", nullable: true),
                    Memory = table.Column<int>(type: "int", nullable: true),
                    Misc = table.Column<int>(type: "int", nullable: true),
                    Ports = table.Column<int>(type: "int", nullable: true),
                    Power = table.Column<int>(type: "int", nullable: true),
                    Processor = table.Column<int>(type: "int", nullable: true),
                    Storage = table.Column<int>(type: "int", nullable: true),
                    PC_MODEL_STATUS = table.Column<string>(type: "longtext", nullable: false)
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
                    table.PrimaryKey("PK_PcModel", x => x.PC_MODEL_ID);
                    table.ForeignKey(
                        name: "FK_PcModel_AuthUser_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PcModel_AuthUser_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                    table.ForeignKey(
                        name: "FK_PcModel_AuthUser_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                    table.ForeignKey(
                        name: "FK_PcModel_ConfigCasing_Casing",
                        column: x => x.Casing,
                        principalTable: "ConfigCasing",
                        principalColumn: "CONFIG_CASING_ID");
                    table.ForeignKey(
                        name: "FK_PcModel_ConfigDisplay_Display",
                        column: x => x.Display,
                        principalTable: "ConfigDisplay",
                        principalColumn: "CONFIG_DISPLAY_ID");
                    table.ForeignKey(
                        name: "FK_PcModel_ConfigGraphics_Graphics",
                        column: x => x.Graphics,
                        principalTable: "ConfigGraphics",
                        principalColumn: "CONFIG_GRAPHICS_ID");
                    table.ForeignKey(
                        name: "FK_PcModel_ConfigMemory_Memory",
                        column: x => x.Memory,
                        principalTable: "ConfigMemory",
                        principalColumn: "CONFIG_MEMORY_ID");
                    table.ForeignKey(
                        name: "FK_PcModel_ConfigMisc_Misc",
                        column: x => x.Misc,
                        principalTable: "ConfigMisc",
                        principalColumn: "CONFIG_MISC_ID");
                    table.ForeignKey(
                        name: "FK_PcModel_ConfigPorts_Ports",
                        column: x => x.Ports,
                        principalTable: "ConfigPorts",
                        principalColumn: "CONFIG_PORTS_ID");
                    table.ForeignKey(
                        name: "FK_PcModel_ConfigPower_Power",
                        column: x => x.Power,
                        principalTable: "ConfigPower",
                        principalColumn: "CONFIG_POWER_ID");
                    table.ForeignKey(
                        name: "FK_PcModel_ConfigProcessor_Processor",
                        column: x => x.Processor,
                        principalTable: "ConfigProcessor",
                        principalColumn: "CONFIG_PROCESSOR_ID");
                    table.ForeignKey(
                        name: "FK_PcModel_ConfigStorage_Storage",
                        column: x => x.Storage,
                        principalTable: "ConfigStorage",
                        principalColumn: "CONFIG_STORAGE_ID");
                    table.ForeignKey(
                        name: "FK_PcModel_PcSeries_PcSeries",
                        column: x => x.PcSeries,
                        principalTable: "PcSeries",
                        principalColumn: "PC_SERIES_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PcModel_Casing",
                table: "PcModel",
                column: "Casing");

            migrationBuilder.CreateIndex(
                name: "IX_PcModel_CreatedBy",
                table: "PcModel",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PcModel_DeletedBy",
                table: "PcModel",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PcModel_Display",
                table: "PcModel",
                column: "Display");

            migrationBuilder.CreateIndex(
                name: "IX_PcModel_Graphics",
                table: "PcModel",
                column: "Graphics");

            migrationBuilder.CreateIndex(
                name: "IX_PcModel_Memory",
                table: "PcModel",
                column: "Memory");

            migrationBuilder.CreateIndex(
                name: "IX_PcModel_Misc",
                table: "PcModel",
                column: "Misc");

            migrationBuilder.CreateIndex(
                name: "IX_PcModel_ModifiedBy",
                table: "PcModel",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PcModel_PcSeries",
                table: "PcModel",
                column: "PcSeries");

            migrationBuilder.CreateIndex(
                name: "IX_PcModel_Ports",
                table: "PcModel",
                column: "Ports");

            migrationBuilder.CreateIndex(
                name: "IX_PcModel_Power",
                table: "PcModel",
                column: "Power");

            migrationBuilder.CreateIndex(
                name: "IX_PcModel_Processor",
                table: "PcModel",
                column: "Processor");

            migrationBuilder.CreateIndex(
                name: "IX_PcModel_Storage",
                table: "PcModel",
                column: "Storage");

            migrationBuilder.AddForeignKey(
                name: "FK_PcSeries_PcCategory_PcCategory",
                table: "PcSeries",
                column: "PcCategory",
                principalTable: "PcCategory",
                principalColumn: "PC_CATEGORY_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PcSeries_PcCategory_PcCategory",
                table: "PcSeries");

            migrationBuilder.DropTable(
                name: "PcModel");

            migrationBuilder.RenameColumn(
                name: "PcCategory",
                table: "PcSeries",
                newName: "PcSeries");

            migrationBuilder.RenameIndex(
                name: "IX_PcSeries_PcCategory",
                table: "PcSeries",
                newName: "IX_PcSeries_PcSeries");

            migrationBuilder.AddForeignKey(
                name: "FK_PcSeries_PcCategory_PcSeries",
                table: "PcSeries",
                column: "PcSeries",
                principalTable: "PcCategory",
                principalColumn: "PC_CATEGORY_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
