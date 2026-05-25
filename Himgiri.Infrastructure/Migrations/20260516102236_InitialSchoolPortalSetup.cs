using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Himgiri.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchoolPortalSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GstSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    HsnCode = table.Column<string>(type: "text", nullable: false),
                    GstPercent = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    CgstPercent = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    SgstPercent = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    EffectiveFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GstSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    HsnCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    GstPercent = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Grade = table.Column<int>(type: "integer", nullable: false),
                    StockQty = table.Column<int>(type: "integer", nullable: false),
                    StorageStatus = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CustomerName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Mobile = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    AddressLine1 = table.Column<string>(type: "text", nullable: false),
                    AddressLine2 = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Pincode = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    Grade = table.Column<int>(type: "integer", nullable: false),
                    SubTotal = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    TotalGst = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    DeliveryFee = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    DeliveryGst = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    GrandTotal = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: false),
                    JodoPaymentId = table.Column<string>(type: "text", nullable: true),
                    AdminNotes = table.Column<string>(type: "text", nullable: true),
                    IsRefunded = table.Column<bool>(type: "boolean", nullable: false),
                    RefundReason = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ContactNumber = table.Column<string>(type: "text", nullable: false),
                    GstNumber = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendorSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    Gstin = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ContactEmail = table.Column<string>(type: "text", nullable: false),
                    ContactPhone = table.Column<string>(type: "text", nullable: false),
                    InvoicePrefix = table.Column<string>(type: "text", nullable: false),
                    LastInvoiceNumber = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    OldQty = table.Column<int>(type: "integer", nullable: false),
                    NewQty = table.Column<int>(type: "integer", nullable: false),
                    ChangedBy = table.Column<string>(type: "text", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockLogs_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemName = table.Column<string>(type: "text", nullable: false),
                    HsnCode = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    GstPercent = table.Column<decimal>(type: "numeric", nullable: false),
                    GstAmount = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    Cgst = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    Sgst = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    LineTotal = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uuid", nullable: false),
                    SupplierInvoiceNo = table.Column<string>(type: "text", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalCost = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    IsCancelled = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PurchaseOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitCost = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    LineTotal = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItems_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdminUsers",
                columns: new[] { "Id", "CreatedAt", "Email", "IsActive", "LastLoginAt", "Name", "PasswordHash", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0001-000000000001"), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6471), "superadmin@himgirigoods.com", true, null, "Super Admin", "$2a$11$rBV2JDeWW3.vKyeCtBiWMurq3vm5JJ1PsHpFN0nHT5hGDYSc3wGWe", 0, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6472) },
                    { new Guid("00000000-0000-0000-0001-000000000002"), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6476), "pradeep@himgirigoods.com", true, null, "Pradeep Jagadale", "$2a$11$rBV2JDeWW3.vKyeCtBiWMurq3vm5JJ1PsHpFN0nHT5hGDYSc3wGWe", 0, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6477) },
                    { new Guid("00000000-0000-0000-0001-000000000003"), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6480), "inventory@himgirigoods.com", true, null, "Inventory Manager", "$2a$11$rBV2JDeWW3.vKyeCtBiWMurq3vm5JJ1PsHpFN0nHT5hGDYSc3wGWe", 1, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6481) },
                    { new Guid("00000000-0000-0000-0001-000000000004"), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6484), "orders1@himgirigoods.com", true, null, "Order Manager 1", "$2a$11$rBV2JDeWW3.vKyeCtBiWMurq3vm5JJ1PsHpFN0nHT5hGDYSc3wGWe", 2, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6485) },
                    { new Guid("00000000-0000-0000-0001-000000000005"), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6488), "orders2@himgirigoods.com", true, null, "Order Manager 2", "$2a$11$rBV2JDeWW3.vKyeCtBiWMurq3vm5JJ1PsHpFN0nHT5hGDYSc3wGWe", 2, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6488) }
                });

            migrationBuilder.InsertData(
                table: "GstSettings",
                columns: new[] { "Id", "Category", "CgstPercent", "CreatedAt", "EffectiveFrom", "GstPercent", "HsnCode", "IsActive", "SgstPercent", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0002-000000000001"), 0, 0m, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6764), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6738), 0m, "4901", true, 0m, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6765) },
                    { new Guid("00000000-0000-0000-0002-000000000002"), 3, 6m, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6772), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6766), 12m, "4820", true, 6m, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6773) },
                    { new Guid("00000000-0000-0000-0002-000000000003"), 1, 6m, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6777), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6773), 12m, "4820", true, 6m, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6778) },
                    { new Guid("00000000-0000-0000-0002-000000000004"), 2, 9m, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6781), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6778), 18m, "4202", true, 9m, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6782) },
                    { new Guid("00000000-0000-0000-0002-000000000005"), 4, 9m, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6785), new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6782), 18m, "9965", true, 9m, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6786) }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Grade", "GstPercent", "HsnCode", "IsActive", "Name", "Price", "StockQty", "StorageStatus", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0004-000000000001"), 3, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6864), "DPS Hinjawadi School Almanac", 2, 12m, "4820", true, "Almanac 2026-27", 150m, 200, 0, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6864) },
                    { new Guid("00000000-0000-0000-0004-000000000002"), 1, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6869), "DPS Hinjawadi Portfolio File", 2, 12m, "4820", true, "Portfolio File", 80m, 200, 0, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6869) },
                    { new Guid("00000000-0000-0000-0004-000000000003"), 3, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6877), "DPS Public Speaking Journal", 2, 12m, "4820", true, "Public Speaking Journal", 120m, 200, 0, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6877) },
                    { new Guid("00000000-0000-0000-0004-000000000004"), 0, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6881), "Marathi Theme Book — delivered to classroom June 2026", 2, 0m, "4901", true, "Majet Shikuya Marathi", 90m, 200, 1, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6882) },
                    { new Guid("00000000-0000-0000-0004-000000000005"), 0, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6886), "Grade 2 Theme Book — delivered to classroom June 2026", 2, 0m, "4901", true, "Theme Book Grade 2", 110m, 200, 1, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6886) }
                });

            migrationBuilder.InsertData(
                table: "VendorSettings",
                columns: new[] { "Id", "Address", "CompanyName", "ContactEmail", "ContactPhone", "CreatedAt", "Gstin", "InvoicePrefix", "LastInvoiceNumber", "UpdatedAt" },
                values: new object[] { new Guid("00000000-0000-0000-0003-000000000001"), "Hinjawadi, Pune, Maharashtra", "Himgiri Goods Pvt. Ltd", "support@himgirigoods.com", "PENDING_FROM_CLIENT", new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6820), "PENDING_FROM_CLIENT", "HG", 0, new DateTime(2026, 5, 16, 10, 22, 34, 67, DateTimeKind.Utc).AddTicks(6821) });

            migrationBuilder.CreateIndex(
                name: "IX_AdminUsers_Email",
                table: "AdminUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_Grade",
                table: "Items",
                column: "Grade");

            migrationBuilder.CreateIndex(
                name: "IX_Items_IsActive",
                table: "Items",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemId",
                table: "OrderItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedAt",
                table: "Orders",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InvoiceNumber",
                table: "Orders",
                column: "InvoiceNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentStatus",
                table: "Orders",
                column: "PaymentStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Status",
                table: "Orders",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_ItemId",
                table: "PurchaseOrderItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_PurchaseOrderId",
                table: "PurchaseOrderItems",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_SupplierId",
                table: "PurchaseOrders",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_StockLogs_ItemId",
                table: "StockLogs",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.DropTable(
                name: "GstSettings");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "PurchaseOrderItems");

            migrationBuilder.DropTable(
                name: "StockLogs");

            migrationBuilder.DropTable(
                name: "VendorSettings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
