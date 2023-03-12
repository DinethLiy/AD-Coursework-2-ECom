using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eComMaster.Migrations
{
    public partial class Add_PC_Config_Items_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigCasing",
                columns: table => new
                {
                    CONFIG_CASING_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CASING_NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CASING_DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BASE_PRICE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CASING_STATUS = table.Column<string>(type: "longtext", nullable: false)
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
                    table.PrimaryKey("PK_ConfigCasing", x => x.CONFIG_CASING_ID);
                    table.ForeignKey(
                        name: "FK_ConfigCasing_AuthUser_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigCasing_AuthUser_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                    table.ForeignKey(
                        name: "FK_ConfigCasing_AuthUser_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConfigDisplay",
                columns: table => new
                {
                    CONFIG_DISPLAY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DISPLAY_NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DISPLAY_DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BASE_PRICE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    DISPLAY_STATUS = table.Column<string>(type: "longtext", nullable: false)
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
                    table.PrimaryKey("PK_ConfigDisplay", x => x.CONFIG_DISPLAY_ID);
                    table.ForeignKey(
                        name: "FK_ConfigDisplay_AuthUser_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigDisplay_AuthUser_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                    table.ForeignKey(
                        name: "FK_ConfigDisplay_AuthUser_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConfigGraphics",
                columns: table => new
                {
                    CONFIG_GRAPHICS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GRAPHICS_NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GRAPHICS_DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BASE_PRICE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    GRAPHICS_STATUS = table.Column<string>(type: "longtext", nullable: false)
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
                    table.PrimaryKey("PK_ConfigGraphics", x => x.CONFIG_GRAPHICS_ID);
                    table.ForeignKey(
                        name: "FK_ConfigGraphics_AuthUser_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigGraphics_AuthUser_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                    table.ForeignKey(
                        name: "FK_ConfigGraphics_AuthUser_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConfigMemory",
                columns: table => new
                {
                    CONFIG_MEMORY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MEMORY_NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MEMORY_DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BASE_PRICE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    MEMORY_STATUS = table.Column<string>(type: "longtext", nullable: false)
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
                    table.PrimaryKey("PK_ConfigMemory", x => x.CONFIG_MEMORY_ID);
                    table.ForeignKey(
                        name: "FK_ConfigMemory_AuthUser_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigMemory_AuthUser_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                    table.ForeignKey(
                        name: "FK_ConfigMemory_AuthUser_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConfigMisc",
                columns: table => new
                {
                    CONFIG_MISC_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MISC_NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MISC_DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BASE_PRICE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    MISC_STATUS = table.Column<string>(type: "longtext", nullable: false)
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
                    table.PrimaryKey("PK_ConfigMisc", x => x.CONFIG_MISC_ID);
                    table.ForeignKey(
                        name: "FK_ConfigMisc_AuthUser_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigMisc_AuthUser_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                    table.ForeignKey(
                        name: "FK_ConfigMisc_AuthUser_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConfigPorts",
                columns: table => new
                {
                    CONFIG_PORTS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PORTS_NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PORTS_DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BASE_PRICE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PORTS_STATUS = table.Column<string>(type: "longtext", nullable: false)
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
                    table.PrimaryKey("PK_ConfigPorts", x => x.CONFIG_PORTS_ID);
                    table.ForeignKey(
                        name: "FK_ConfigPorts_AuthUser_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigPorts_AuthUser_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                    table.ForeignKey(
                        name: "FK_ConfigPorts_AuthUser_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConfigPower",
                columns: table => new
                {
                    CONFIG_POWER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    POWER_NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    POWER_DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BASE_PRICE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    POWER_STATUS = table.Column<string>(type: "longtext", nullable: false)
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
                    table.PrimaryKey("PK_ConfigPower", x => x.CONFIG_POWER_ID);
                    table.ForeignKey(
                        name: "FK_ConfigPower_AuthUser_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigPower_AuthUser_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                    table.ForeignKey(
                        name: "FK_ConfigPower_AuthUser_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConfigProcessor",
                columns: table => new
                {
                    CONFIG_PROCESSOR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PROCESSOR_NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PROCESSOR_DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BASE_PRICE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PROCESSOR_STATUS = table.Column<string>(type: "longtext", nullable: false)
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
                    table.PrimaryKey("PK_ConfigProcessor", x => x.CONFIG_PROCESSOR_ID);
                    table.ForeignKey(
                        name: "FK_ConfigProcessor_AuthUser_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigProcessor_AuthUser_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                    table.ForeignKey(
                        name: "FK_ConfigProcessor_AuthUser_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConfigStorage",
                columns: table => new
                {
                    CONFIG_STORAGE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    STORAGE_NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    STORAGE_DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BASE_PRICE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    STORAGE_STATUS = table.Column<string>(type: "longtext", nullable: false)
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
                    table.PrimaryKey("PK_ConfigStorage", x => x.CONFIG_STORAGE_ID);
                    table.ForeignKey(
                        name: "FK_ConfigStorage_AuthUser_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigStorage_AuthUser_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                    table.ForeignKey(
                        name: "FK_ConfigStorage_AuthUser_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "AuthUser",
                        principalColumn: "USER_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigCasing_CreatedBy",
                table: "ConfigCasing",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigCasing_DeletedBy",
                table: "ConfigCasing",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigCasing_ModifiedBy",
                table: "ConfigCasing",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigDisplay_CreatedBy",
                table: "ConfigDisplay",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigDisplay_DeletedBy",
                table: "ConfigDisplay",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigDisplay_ModifiedBy",
                table: "ConfigDisplay",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigGraphics_CreatedBy",
                table: "ConfigGraphics",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigGraphics_DeletedBy",
                table: "ConfigGraphics",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigGraphics_ModifiedBy",
                table: "ConfigGraphics",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigMemory_CreatedBy",
                table: "ConfigMemory",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigMemory_DeletedBy",
                table: "ConfigMemory",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigMemory_ModifiedBy",
                table: "ConfigMemory",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigMisc_CreatedBy",
                table: "ConfigMisc",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigMisc_DeletedBy",
                table: "ConfigMisc",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigMisc_ModifiedBy",
                table: "ConfigMisc",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigPorts_CreatedBy",
                table: "ConfigPorts",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigPorts_DeletedBy",
                table: "ConfigPorts",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigPorts_ModifiedBy",
                table: "ConfigPorts",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigPower_CreatedBy",
                table: "ConfigPower",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigPower_DeletedBy",
                table: "ConfigPower",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigPower_ModifiedBy",
                table: "ConfigPower",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigProcessor_CreatedBy",
                table: "ConfigProcessor",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigProcessor_DeletedBy",
                table: "ConfigProcessor",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigProcessor_ModifiedBy",
                table: "ConfigProcessor",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigStorage_CreatedBy",
                table: "ConfigStorage",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigStorage_DeletedBy",
                table: "ConfigStorage",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigStorage_ModifiedBy",
                table: "ConfigStorage",
                column: "ModifiedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigCasing");

            migrationBuilder.DropTable(
                name: "ConfigDisplay");

            migrationBuilder.DropTable(
                name: "ConfigGraphics");

            migrationBuilder.DropTable(
                name: "ConfigMemory");

            migrationBuilder.DropTable(
                name: "ConfigMisc");

            migrationBuilder.DropTable(
                name: "ConfigPorts");

            migrationBuilder.DropTable(
                name: "ConfigPower");

            migrationBuilder.DropTable(
                name: "ConfigProcessor");

            migrationBuilder.DropTable(
                name: "ConfigStorage");
        }
    }
}
