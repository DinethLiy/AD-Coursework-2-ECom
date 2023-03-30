using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eComMaster.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AuthUser",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    USERNAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PASSWORD = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PRIVILEGE_TYPE = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    USER_STATUS = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUser", x => x.USER_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                    PcCategory = table.Column<int>(type: "int", nullable: false),
                    PC_SERIES_NAME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PC_SERIES_DESCRIPTION = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PC_SERIES_STATUS = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                        name: "FK_PcSeries_PcCategory_PcCategory",
                        column: x => x.PcCategory,
                        principalTable: "PcCategory",
                        principalColumn: "PC_CATEGORY_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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
                    MODIFIED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DELETED_DATE = table.Column<DateTime>(type: "datetime(6)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "CheckoutModel",
                columns: table => new
                {
                    CHECKOUT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameBilling = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BillingAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BillingCity = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BillingState = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BillingZip = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameShipping = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShippingAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShippingCity = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShippingState = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShippingZip = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ORDER_ID = table.Column<int>(type: "int", nullable: false),
                    SameAddress = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutModel", x => x.CHECKOUT_ID);
                    table.ForeignKey(
                        name: "FK_CheckoutModel_Order_ORDER_ID",
                        column: x => x.ORDER_ID,
                        principalTable: "Order",
                        principalColumn: "ORDER_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutModel_ORDER_ID",
                table: "CheckoutModel",
                column: "ORDER_ID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Customer_AuthUser",
                table: "Customer",
                column: "AuthUser");

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

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ORDER_ID",
                table: "Payment",
                column: "ORDER_ID");

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
                name: "IX_PcSeries_PcCategory",
                table: "PcSeries",
                column: "PcCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CheckoutModel");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "PcModel");

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

            migrationBuilder.DropTable(
                name: "PcSeries");

            migrationBuilder.DropTable(
                name: "PcCategory");

            migrationBuilder.DropTable(
                name: "AuthUser");
        }
    }
}
