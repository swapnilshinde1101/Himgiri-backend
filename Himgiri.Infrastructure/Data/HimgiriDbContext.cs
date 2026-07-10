using Himgiri.Core.Entities;
using Himgiri.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Himgiri.Infrastructure.Data;

public class HimgiriDbContext : DbContext
{
    public HimgiriDbContext(DbContextOptions<HimgiriDbContext> options) : base(options) { }

    public DbSet<Item> Items => Set<Item>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<AdminUser> AdminUsers => Set<AdminUser>();
    public DbSet<StockLog> StockLogs => Set<StockLog>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
    public DbSet<PurchaseOrderItem> PurchaseOrderItems => Set<PurchaseOrderItem>();
    public DbSet<Grade> Grades => Set<Grade>();
    public DbSet<ItemCategory> ItemCategories => Set<ItemCategory>();
    public DbSet<GstRate> GstRates => Set<GstRate>();
    public DbSet<State> States => Set<State>();
    public DbSet<VendorSettings> VendorSettings => Set<VendorSettings>();
    public DbSet<ApiErrorLog> ApiErrorLogs => Set<ApiErrorLog>();
    public DbSet<ItemGrade> ItemGrades => Set<ItemGrade>();
    public DbSet<PriceAuditLog> PriceAuditLogs => Set<PriceAuditLog>();
    public DbSet<OrderStatusHistory> OrderStatusHistories => Set<OrderStatusHistory>();
    public DbSet<SchoolKit> SchoolKits => Set<SchoolKit>();
    public DbSet<SchoolKitItem> SchoolKitItems => Set<SchoolKitItem>();
    public DbSet<Himgiri.Infrastructure.Data.Models.SpGetItemsPagedResult> SpGetItemsPagedResults => Set<Himgiri.Infrastructure.Data.Models.SpGetItemsPagedResult>();
    public DbSet<Himgiri.Infrastructure.Data.Models.SpGetGradesPagedResult> SpGetGradesPagedResults => Set<Himgiri.Infrastructure.Data.Models.SpGetGradesPagedResult>();
    public DbSet<Himgiri.Infrastructure.Data.Models.SpGetCategoriesPagedResult> SpGetCategoriesPagedResults => Set<Himgiri.Infrastructure.Data.Models.SpGetCategoriesPagedResult>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ── Stored Procedure Results ──
        modelBuilder.Entity<Himgiri.Infrastructure.Data.Models.SpGetItemsPagedResult>().HasNoKey().ToTable((string?)null);
        modelBuilder.Entity<Himgiri.Infrastructure.Data.Models.SpGetGradesPagedResult>().HasNoKey().ToTable((string?)null);
        modelBuilder.Entity<Himgiri.Infrastructure.Data.Models.SpGetCategoriesPagedResult>().HasNoKey().ToTable((string?)null);

        // ── Support Entities ──
        modelBuilder.Entity<Grade>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(50);
            e.Property(x => x.ShortName).HasMaxLength(10);
        });

        modelBuilder.Entity<ItemCategory>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(100);
            e.HasOne(x => x.DefaultGstRate)
             .WithMany()
             .HasForeignKey(x => x.DefaultGstRateId)
             .OnDelete(DeleteBehavior.Restrict)
             .IsRequired();
        });

        modelBuilder.Entity<GstRate>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(100);
            e.Property(x => x.HsnCode).IsRequired().HasMaxLength(20);
            e.Property(x => x.Rate).HasPrecision(5, 2);
            e.Property(x => x.Cgst).HasPrecision(5, 2);
            e.Property(x => x.Sgst).HasPrecision(5, 2);
            e.Property(x => x.Igst).HasPrecision(5, 2);
            e.Property(x => x.Cess).HasPrecision(5, 2);
        });

        // ── State ──
        modelBuilder.Entity<State>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.StateCode).IsRequired().HasMaxLength(10);
            e.Property(x => x.StateName).IsRequired().HasMaxLength(100);
            e.Property(x => x.GstStateCode).IsRequired().HasMaxLength(10);
        });

        // ── ApiErrorLog ──
        modelBuilder.Entity<ApiErrorLog>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Url).HasMaxLength(2000);
            e.Property(x => x.Payload).HasColumnType("text");
            e.Property(x => x.Response).HasColumnType("text");
        });

        // ── Item ──
        modelBuilder.Entity<Item>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(200);
            e.Property(x => x.Price).HasPrecision(10, 2);
            e.Property(x => x.PurchasePrice).HasPrecision(10, 2);
            e.Property(x => x.Mrp).HasPrecision(10, 2);
            e.Property(x => x.Unit).HasMaxLength(50).HasDefaultValue("Pieces (Pcs)");
            e.HasOne(x => x.Category).WithMany(c => c.Items).HasForeignKey(x => x.CategoryId);
            e.HasOne(x => x.GstRate)
             .WithMany()
             .HasForeignKey(x => x.GstRateId)
             .OnDelete(DeleteBehavior.Restrict);
            e.HasIndex(x => x.IsActive);
        });

        // ── ItemGrade Many-to-Many ──
        modelBuilder.Entity<ItemGrade>(e =>
        {
            e.HasKey(ig => new { ig.ItemId, ig.GradeId });
            e.HasOne(ig => ig.Item).WithMany(i => i.ItemGrades).HasForeignKey(ig => ig.ItemId);
            e.HasOne(ig => ig.Grade).WithMany(g => g.ItemGrades).HasForeignKey(ig => ig.GradeId);
        });

        // ── Order ──
        modelBuilder.Entity<Order>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.InvoiceNumber).IsRequired().HasMaxLength(20);
            e.HasIndex(x => x.InvoiceNumber).IsUnique();
            e.Property(x => x.CustomerName).IsRequired().HasMaxLength(200);
            e.Property(x => x.Email).HasMaxLength(200);
            e.Property(x => x.Mobile).IsRequired().HasMaxLength(15);
            e.Property(x => x.Pincode).IsRequired().HasMaxLength(6);
            e.Property(x => x.SubTotal).HasPrecision(18, 2);
            e.Property(x => x.TotalGst).HasPrecision(18, 2);
            e.Property(x => x.DeliveryFee).HasPrecision(18, 2);
            e.Property(x => x.DeliveryGst).HasPrecision(18, 2);
            e.Property(x => x.DeliveryCgstAmount).HasPrecision(18, 2);
            e.Property(x => x.DeliverySgstAmount).HasPrecision(18, 2);
            e.Property(x => x.DeliveryIgstAmount).HasPrecision(18, 2);
            e.Property(x => x.GrandTotal).HasPrecision(18, 2);
            e.Property(x => x.CustomerGstin).HasMaxLength(15);
            e.Property(x => x.SellerCompanyName).IsRequired().HasMaxLength(200);
            e.Property(x => x.SellerGstin).IsRequired(false).HasMaxLength(15);
            e.Property(x => x.SellerAddress).IsRequired().HasMaxLength(500);
            e.Property(x => x.SellerStateName).IsRequired().HasMaxLength(100);
            e.Property(x => x.SellerGstStateCode).IsRequired().HasMaxLength(10);
            e.Property(x => x.CustomerStateName).IsRequired().HasMaxLength(100);
            e.Property(x => x.CustomerGstStateCode).IsRequired().HasMaxLength(10);
            e.Property(x => x.PlaceOfSupply).IsRequired().HasMaxLength(100);
            e.Property(x => x.PlaceOfSupplyCode).IsRequired().HasMaxLength(10);
            e.HasIndex(x => x.PaymentStatus);
            e.HasIndex(x => x.Status);
            e.HasIndex(x => x.CreatedAt);
            e.HasOne(x => x.Grade).WithMany().HasForeignKey(x => x.GradeId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
            e.HasIndex(x => x.GradeId);

            e.HasOne(x => x.SellerState).WithMany().HasForeignKey(x => x.SellerStateId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.CustomerState).WithMany().HasForeignKey(x => x.CustomerStateId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        });

        // ── OrderItem ──
        modelBuilder.Entity<OrderItem>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.ItemName).IsRequired().HasMaxLength(200);
            e.Property(x => x.HsnCode).IsRequired().HasMaxLength(20);
            e.Property(x => x.UnitPrice).HasPrecision(18, 2);
            e.Property(x => x.BaseAmount).HasPrecision(18, 2);
            e.Property(x => x.GstPercent).HasPrecision(5, 2);
            e.Property(x => x.CgstPercent).HasPrecision(5, 2);
            e.Property(x => x.SgstPercent).HasPrecision(5, 2);
            e.Property(x => x.IgstPercent).HasPrecision(5, 2);
            e.Property(x => x.CessPercent).HasPrecision(5, 2);
            e.Property(x => x.GstAmount).HasPrecision(18, 2);
            e.Property(x => x.CgstAmount).HasPrecision(18, 2);
            e.Property(x => x.SgstAmount).HasPrecision(18, 2);
            e.Property(x => x.IgstAmount).HasPrecision(18, 2);
            e.Property(x => x.CessAmount).HasPrecision(18, 2);
            e.Property(x => x.LineTotal).HasPrecision(18, 2);
            e.HasOne(x => x.Order).WithMany(x => x.Items).HasForeignKey(x => x.OrderId);
            e.HasOne(x => x.Item).WithMany(x => x.OrderItems).HasForeignKey(x => x.ItemId);
        });

        // ── AdminUser ──
        modelBuilder.Entity<AdminUser>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Email).IsRequired().HasMaxLength(200);
            e.HasIndex(x => x.Email).IsUnique();
        });

        // ── StockLog ──
        modelBuilder.Entity<StockLog>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.Item).WithMany(x => x.StockLogs).HasForeignKey(x => x.ItemId);
        });

        // ── PurchaseOrder ──
        modelBuilder.Entity<PurchaseOrder>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.TotalCost).HasPrecision(10, 2);
            e.HasOne(x => x.Supplier).WithMany(x => x.PurchaseOrders).HasForeignKey(x => x.SupplierId);
        });

        // ── PurchaseOrderItem ──
        modelBuilder.Entity<PurchaseOrderItem>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.UnitCost).HasPrecision(10, 2);
            e.Property(x => x.LineTotal).HasPrecision(10, 2);
            e.HasOne(x => x.PurchaseOrder).WithMany(x => x.Items).HasForeignKey(x => x.PurchaseOrderId);
            e.HasOne(x => x.Item).WithMany(x => x.PurchaseOrderItems).HasForeignKey(x => x.ItemId);
        });

        modelBuilder.Entity<VendorSettings>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.State)
             .WithMany()
             .HasForeignKey(x => x.StateId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        // ── PriceAuditLog ──
        modelBuilder.Entity<PriceAuditLog>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.OldPrice).HasPrecision(10, 2);
            e.Property(x => x.NewPrice).HasPrecision(10, 2);
            e.Property(x => x.OldMrp).HasPrecision(10, 2);
            e.Property(x => x.NewMrp).HasPrecision(10, 2);
            e.HasOne(x => x.Item).WithMany().HasForeignKey(x => x.ItemId);
        });

        // ── OrderStatusHistory ──
        modelBuilder.Entity<OrderStatusHistory>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.Order).WithMany(o => o.StatusHistories).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Cascade);
        });

        // ── SchoolKit ──
        modelBuilder.Entity<SchoolKit>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(200);
            e.HasOne(x => x.Grade).WithMany().HasForeignKey(x => x.GradeId).OnDelete(DeleteBehavior.Restrict);
            e.HasIndex(x => new { x.GradeId, x.IsActive })
                .IsUnique()
                .HasFilter("\"IsActive\" = true AND \"IsDeleted\" = false");
        });

        // ── SchoolKitItem ──
        modelBuilder.Entity<SchoolKitItem>(e =>
        {
            e.HasKey(ski => new { ski.SchoolKitId, ski.ItemId });
            e.HasOne(ski => ski.SchoolKit).WithMany(sk => sk.KitItems).HasForeignKey(ski => ski.SchoolKitId).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(ski => ski.Item).WithMany().HasForeignKey(ski => ski.ItemId).OnDelete(DeleteBehavior.Restrict);
        });

        // ═══════════════════════════════════════════
        // SEED DATA
        // ═══════════════════════════════════════════

        var passwordHash = "$2a$11$rBV2JDeWW3.vKyeCtBiWMurq3vm5JJ1PsHpFN0nHT5hGDYSc3wGWe"; // Admin@123

        // Admin Users
        modelBuilder.Entity<AdminUser>().HasData(
            new AdminUser { Id = Guid.Parse("00000000-0000-0000-0001-000000000001"), Name = "Super Admin", Email = "superadmin@himgirigoods.com", PasswordHash = passwordHash, Role = AdminRole.SuperAdmin, IsActive = true, CreatedAt = DateTime.UtcNow },
            new AdminUser { Id = Guid.Parse("00000000-0000-0000-0001-000000000002"), Name = "Pradeep Jagadale", Email = "pradeep@himgirigoods.com", PasswordHash = passwordHash, Role = AdminRole.SuperAdmin, IsActive = true, CreatedAt = DateTime.UtcNow },
            new AdminUser { Id = Guid.Parse("00000000-0000-0000-0001-000000000003"), Name = "Inventory Manager", Email = "inventory@himgirigoods.com", PasswordHash = passwordHash, Role = AdminRole.InventoryManager, IsActive = true, CreatedAt = DateTime.UtcNow },
            new AdminUser { Id = Guid.Parse("00000000-0000-0000-0001-000000000004"), Name = "Order Manager 1", Email = "orders1@himgirigoods.com", PasswordHash = passwordHash, Role = AdminRole.OrderManager, IsActive = true, CreatedAt = DateTime.UtcNow },
            new AdminUser { Id = Guid.Parse("00000000-0000-0000-0001-000000000005"), Name = "Order Manager 2", Email = "orders2@himgirigoods.com", PasswordHash = passwordHash, Role = AdminRole.OrderManager, IsActive = true, CreatedAt = DateTime.UtcNow }
        );

        // Grades
        var grade2Id = Guid.Parse("00000000-0000-0000-0005-000000000002");
        modelBuilder.Entity<Grade>().HasData(
            new Grade { Id = Guid.Parse("00000000-0000-0000-0005-000000000001"), Name = "Grade 1", ShortName = "G1", Description = "Primary Grade 1", DisplayOrder = 1, CreatedAt = DateTime.UtcNow },
            new Grade { Id = grade2Id, Name = "Grade 2", ShortName = "G2", Description = "Primary Grade 2", DisplayOrder = 2, CreatedAt = DateTime.UtcNow },
            new Grade { Id = Guid.Parse("00000000-0000-0000-0005-000000000003"), Name = "Grade 3", ShortName = "G3", Description = "Primary Grade 3", DisplayOrder = 3, CreatedAt = DateTime.UtcNow }
        );

        // Categories
        var catTextbookId = Guid.Parse("00000000-0000-0000-0006-000000000001");
        var catStationeryId = Guid.Parse("00000000-0000-0000-0006-000000000002");
        var catJournalId = Guid.Parse("00000000-0000-0000-0006-000000000003");
        var catBagId = Guid.Parse("00000000-0000-0000-0006-000000000004");
        var catDeliveryId = Guid.Parse("00000000-0000-0000-0006-000000000005");

        // GST Rates Seed IDs
        var gstRateIdBooks = Guid.Parse("00000000-0000-0000-0009-000000000001");
        var gstRateIdStationery = Guid.Parse("00000000-0000-0000-0009-000000000002");
        var gstRateIdBags = Guid.Parse("00000000-0000-0000-0009-000000000003");
        var gstRateIdDelivery = Guid.Parse("00000000-0000-0000-0009-000000000004");
        var gstRateIdGst5 = Guid.Parse("00000000-0000-0000-0009-000000000005");
        var gstRateIdGst28 = Guid.Parse("00000000-0000-0000-0009-000000000006");

        modelBuilder.Entity<GstRate>().HasData(
            new GstRate { Id = gstRateIdBooks, Name = "Books Exempt", HsnCode = "4901", Description = "School Textbooks Exempt from GST", Rate = 0m, Cgst = 0m, Sgst = 0m, Igst = 0m, Cess = 0m, EffectiveFrom = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true, CreatedAt = DateTime.UtcNow },
            new GstRate { Id = gstRateIdGst5, Name = "Medicines/Essentials GST 5%", HsnCode = "3004", Description = "Essential items under 5% GST", Rate = 5m, Cgst = 2.5m, Sgst = 2.5m, Igst = 5m, Cess = 0m, EffectiveFrom = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true, CreatedAt = DateTime.UtcNow },
            new GstRate { Id = gstRateIdStationery, Name = "Stationery GST 12%", HsnCode = "4820", Description = "Notebooks and Stationery items under 12% GST", Rate = 12m, Cgst = 6m, Sgst = 6m, Igst = 12m, Cess = 0m, EffectiveFrom = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true, CreatedAt = DateTime.UtcNow },
            new GstRate { Id = gstRateIdBags, Name = "Bags GST 18%", HsnCode = "4202", Description = "School Bags and Backpacks under 18% GST", Rate = 18m, Cgst = 9m, Sgst = 9m, Igst = 18m, Cess = 0m, EffectiveFrom = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true, CreatedAt = DateTime.UtcNow },
            new GstRate { Id = gstRateIdDelivery, Name = "Delivery Fee GST 18%", HsnCode = "9965", Description = "Logistics and Shipping charges under 18% GST", Rate = 18m, Cgst = 9m, Sgst = 9m, Igst = 18m, Cess = 0m, EffectiveFrom = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true, CreatedAt = DateTime.UtcNow },
            new GstRate { Id = gstRateIdGst28, Name = "Luxury/Services GST 28%", HsnCode = "8708", Description = "Luxury goods and services under 28% GST", Rate = 28m, Cgst = 14m, Sgst = 14m, Igst = 28m, Cess = 0m, EffectiveFrom = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc), IsActive = true, CreatedAt = DateTime.UtcNow }
        );

        modelBuilder.Entity<ItemCategory>().HasData(
            new { Id = catTextbookId, Name = "Textbook", Description = "School Textbooks", IsActive = true, IsDeleted = false, CreatedAt = DateTime.UtcNow, DisplayOrder = 1, DefaultGstRateId = (Guid?)gstRateIdBooks },
            new { Id = catStationeryId, Name = "Stationery", Description = "School Stationery", IsActive = true, IsDeleted = false, CreatedAt = DateTime.UtcNow, DisplayOrder = 2, DefaultGstRateId = (Guid?)gstRateIdStationery },
            new { Id = catJournalId, Name = "Journal", Description = "School Journals", IsActive = true, IsDeleted = false, CreatedAt = DateTime.UtcNow, DisplayOrder = 3, DefaultGstRateId = (Guid?)gstRateIdStationery },
            new { Id = catBagId, Name = "Bag", Description = "School Bags", IsActive = true, IsDeleted = false, CreatedAt = DateTime.UtcNow, DisplayOrder = 4, DefaultGstRateId = (Guid?)gstRateIdBags },
            new { Id = catDeliveryId, Name = "Delivery Fee", Description = "Delivery Charges", IsActive = true, IsDeleted = false, CreatedAt = DateTime.UtcNow, DisplayOrder = 5, DefaultGstRateId = (Guid?)gstRateIdDelivery }
        );

        // States & Union Territories Master Seed (36 jurisdictions)
        modelBuilder.Entity<State>().HasData(
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000001"), StateName = "Jammu & Kashmir", StateCode = "JK", GstStateCode = "01", IsUnionTerritory = true, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000002"), StateName = "Himachal Pradesh", StateCode = "HP", GstStateCode = "02", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000003"), StateName = "Punjab", StateCode = "PB", GstStateCode = "03", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000004"), StateName = "Chandigarh", StateCode = "CH", GstStateCode = "04", IsUnionTerritory = true, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000005"), StateName = "Uttarakhand", StateCode = "UT", GstStateCode = "05", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000006"), StateName = "Haryana", StateCode = "HR", GstStateCode = "06", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000007"), StateName = "Delhi", StateCode = "DL", GstStateCode = "07", IsUnionTerritory = true, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000008"), StateName = "Rajasthan", StateCode = "RJ", GstStateCode = "08", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000009"), StateName = "Uttar Pradesh", StateCode = "UP", GstStateCode = "09", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000010"), StateName = "Bihar", StateCode = "BR", GstStateCode = "10", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000011"), StateName = "Sikkim", StateCode = "SK", GstStateCode = "11", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000012"), StateName = "Arunachal Pradesh", StateCode = "AR", GstStateCode = "12", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000013"), StateName = "Nagaland", StateCode = "NL", GstStateCode = "13", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000014"), StateName = "Manipur", StateCode = "MN", GstStateCode = "14", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000015"), StateName = "Mizoram", StateCode = "MZ", GstStateCode = "15", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000016"), StateName = "Tripura", StateCode = "TR", GstStateCode = "16", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000017"), StateName = "Meghalaya", StateCode = "ML", GstStateCode = "17", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000018"), StateName = "Assam", StateCode = "AS", GstStateCode = "18", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000019"), StateName = "West Bengal", StateCode = "WB", GstStateCode = "19", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000020"), StateName = "Jharkhand", StateCode = "JH", GstStateCode = "20", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000021"), StateName = "Odisha", StateCode = "OR", GstStateCode = "21", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000022"), StateName = "Chhattisgarh", StateCode = "CG", GstStateCode = "22", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000023"), StateName = "Madhya Pradesh", StateCode = "MP", GstStateCode = "23", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000024"), StateName = "Gujarat", StateCode = "GJ", GstStateCode = "24", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000026"), StateName = "Dadra & Nagar Haveli and Daman & Diu", StateCode = "DN", GstStateCode = "26", IsUnionTerritory = true, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000027"), StateName = "Maharashtra", StateCode = "MH", GstStateCode = "27", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000029"), StateName = "Karnataka", StateCode = "KA", GstStateCode = "29", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000030"), StateName = "Goa", StateCode = "GA", GstStateCode = "30", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000031"), StateName = "Lakshadweep", StateCode = "LD", GstStateCode = "31", IsUnionTerritory = true, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000032"), StateName = "Kerala", StateCode = "KL", GstStateCode = "32", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000033"), StateName = "Tamil Nadu", StateCode = "TN", GstStateCode = "33", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000034"), StateName = "Puducherry", StateCode = "PY", GstStateCode = "34", IsUnionTerritory = true, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000035"), StateName = "Andaman & Nicobar Islands", StateCode = "AN", GstStateCode = "35", IsUnionTerritory = true, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000036"), StateName = "Telangana", StateCode = "TG", GstStateCode = "36", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000037"), StateName = "Andhra Pradesh", StateCode = "AP", GstStateCode = "37", IsUnionTerritory = false, IsActive = true, CreatedAt = DateTime.UtcNow },
            new State { Id = Guid.Parse("00000000-0000-0000-0008-000000000038"), StateName = "Ladakh", StateCode = "LA", GstStateCode = "38", IsUnionTerritory = true, IsActive = true, CreatedAt = DateTime.UtcNow }
        );

        // Vendor Settings
        modelBuilder.Entity<VendorSettings>().HasData(
            new VendorSettings 
            { 
                Id = Guid.Parse("00000000-0000-0000-0003-000000000001"), 
                CompanyName = "Himgiri Goods Pvt. Ltd", 
                Gstin = "27GSTIN_PENDING", 
                Address = "Hinjawadi, Pune, Maharashtra", 
                ContactEmail = "support@himgirigoods.com", 
                ContactPhone = "PENDING_FROM_CLIENT", 
                InvoicePrefix = "HG", 
                LastInvoiceNumber = 0, 
                StateId = Guid.Parse("00000000-0000-0000-0008-000000000027"),
                CreatedAt = DateTime.UtcNow 
            }
        );

        // Sample Items linked to Category with Stock/PreOrder properties
        modelBuilder.Entity<Item>().HasData(
            // Grade 1 Items
            new Item { Id = Guid.Parse("00000000-0000-0000-0004-000000000011"), Name = "Grade 1 English Textbook", Description = "Interactive English Reader for Grade 1", ImageUrl = "https://picsum.photos/200/300?random=11", Price = 180, PurchasePrice = 120, Mrp = 180, CategoryId = catTextbookId, GstRateId = gstRateIdBooks, Unit = "Pieces (Pcs)", IsStockInitialized = true, StockQty = 150, TargetQty = 150, StorageStatus = StorageStatus.InStock, CreatedAt = DateTime.UtcNow },
            new Item { Id = Guid.Parse("00000000-0000-0000-0004-000000000012"), Name = "Grade 1 Red Notebook", Description = "Ruled Journal for Grade 1 practice", ImageUrl = "https://picsum.photos/200/300?random=12", Price = 40, PurchasePrice = 25, Mrp = 45, CategoryId = catJournalId, GstRateId = gstRateIdStationery, Unit = "Pieces (Pcs)", IsStockInitialized = true, StockQty = 300, TargetQty = 300, StorageStatus = StorageStatus.InStock, CreatedAt = DateTime.UtcNow },
            new Item { Id = Guid.Parse("00000000-0000-0000-0004-000000000013"), Name = "Grade 1 Premium Pencil Box", Description = "Stationery box containing pencils, eraser, and ruler", ImageUrl = "https://picsum.photos/200/300?random=13", Price = 70, PurchasePrice = 45, Mrp = 80, CategoryId = catStationeryId, GstRateId = gstRateIdStationery, Unit = "Pieces (Pcs)", IsStockInitialized = true, StockQty = 200, TargetQty = 200, StorageStatus = StorageStatus.InStock, CreatedAt = DateTime.UtcNow },

            // Grade 2 Items
            new Item { Id = Guid.Parse("00000000-0000-0000-0004-000000000001"), Name = "Almanac 2026-27", Description = "DPS Hinjawadi School Almanac", ImageUrl = "https://picsum.photos/200/300?random=1", Price = 150, PurchasePrice = 100, Mrp = 180, CategoryId = catJournalId, GstRateId = gstRateIdStationery, Unit = "Pieces (Pcs)", IsStockInitialized = true, StockQty = 120, TargetQty = 150, StorageStatus = StorageStatus.InStock, CreatedAt = DateTime.UtcNow },
            new Item { Id = Guid.Parse("00000000-0000-0000-0004-000000000002"), Name = "Portfolio File", Description = "DPS Hinjawadi Portfolio File", ImageUrl = "https://picsum.photos/200/300?random=2", Price = 80, PurchasePrice = 50, Mrp = 90, CategoryId = catStationeryId, GstRateId = gstRateIdStationery, Unit = "Pieces (Pcs)", IsStockInitialized = true, StockQty = 250, TargetQty = 300, StorageStatus = StorageStatus.InStock, CreatedAt = DateTime.UtcNow },
            new Item { Id = Guid.Parse("00000000-0000-0000-0004-000000000003"), Name = "Public Speaking Journal", Description = "DPS Public Speaking Journal", ImageUrl = "https://picsum.photos/200/300?random=3", Price = 120, PurchasePrice = 80, Mrp = 140, CategoryId = catJournalId, GstRateId = gstRateIdStationery, Unit = "Pieces (Pcs)", IsStockInitialized = true, StockQty = 180, TargetQty = 200, StorageStatus = StorageStatus.InStock, CreatedAt = DateTime.UtcNow },
            new Item { Id = Guid.Parse("00000000-0000-0000-0004-000000000004"), Name = "Majet Shikuya Marathi", Description = "Marathi Theme Book", ImageUrl = "https://picsum.photos/200/300?random=4", Price = 90, PurchasePrice = 60, Mrp = 100, CategoryId = catTextbookId, GstRateId = gstRateIdBooks, Unit = "Pieces (Pcs)", IsStockInitialized = true, StockQty = 90, TargetQty = 100, StorageStatus = StorageStatus.InStock, CreatedAt = DateTime.UtcNow },
            new Item { Id = Guid.Parse("00000000-0000-0000-0004-000000000005"), Name = "Theme Book Grade 2", Description = "Grade 2 Theme Book", ImageUrl = "https://picsum.photos/200/300?random=5", Price = 110, PurchasePrice = 75, Mrp = 130, CategoryId = catTextbookId, GstRateId = gstRateIdBooks, Unit = "Pieces (Pcs)", IsStockInitialized = true, StockQty = 0, TargetQty = 150, StorageStatus = StorageStatus.PreOrder, CreatedAt = DateTime.UtcNow },

            // Grade 3 Items
            new Item { Id = Guid.Parse("00000000-0000-0000-0004-000000000031"), Name = "Grade 3 Math Magic", Description = "Mathematics textbook for Grade 3", ImageUrl = "https://picsum.photos/200/300?random=31", Price = 220, PurchasePrice = 150, Mrp = 220, CategoryId = catTextbookId, GstRateId = gstRateIdBooks, Unit = "Pieces (Pcs)", IsStockInitialized = true, StockQty = 140, TargetQty = 150, StorageStatus = StorageStatus.InStock, CreatedAt = DateTime.UtcNow },
            new Item { Id = Guid.Parse("00000000-0000-0000-0004-000000000032"), Name = "Grade 3 Science Explorer", Description = "Science and environment textbook for Grade 3", ImageUrl = "https://picsum.photos/200/300?random=32", Price = 240, PurchasePrice = 160, Mrp = 240, CategoryId = catTextbookId, GstRateId = gstRateIdBooks, Unit = "Pieces (Pcs)", IsStockInitialized = true, StockQty = 130, TargetQty = 150, StorageStatus = StorageStatus.InStock, CreatedAt = DateTime.UtcNow },
            new Item { Id = Guid.Parse("00000000-0000-0000-0004-000000000033"), Name = "Grade 3 School Bag", Description = "Heavy duty school backpack for Grade 3", ImageUrl = "https://picsum.photos/200/300?random=33", Price = 650, PurchasePrice = 450, Mrp = 750, CategoryId = catBagId, GstRateId = gstRateIdBags, Unit = "Pieces (Pcs)", IsStockInitialized = true, StockQty = 80, TargetQty = 100, StorageStatus = StorageStatus.InStock, CreatedAt = DateTime.UtcNow }
        );

        // Seed ItemGrades Many-to-Many relations
        var grade1Id = Guid.Parse("00000000-0000-0000-0005-000000000001");
        var grade3Id = Guid.Parse("00000000-0000-0000-0005-000000000003");

        modelBuilder.Entity<ItemGrade>().HasData(
            // Grade 1 Item linkages
            new ItemGrade { ItemId = Guid.Parse("00000000-0000-0000-0004-000000000011"), GradeId = grade1Id },
            new ItemGrade { ItemId = Guid.Parse("00000000-0000-0000-0004-000000000012"), GradeId = grade1Id },
            new ItemGrade { ItemId = Guid.Parse("00000000-0000-0000-0004-000000000013"), GradeId = grade1Id },

            // Grade 2 Item linkages
            new ItemGrade { ItemId = Guid.Parse("00000000-0000-0000-0004-000000000001"), GradeId = grade2Id },
            new ItemGrade { ItemId = Guid.Parse("00000000-0000-0000-0004-000000000002"), GradeId = grade2Id },
            new ItemGrade { ItemId = Guid.Parse("00000000-0000-0000-0004-000000000003"), GradeId = grade2Id },
            new ItemGrade { ItemId = Guid.Parse("00000000-0000-0000-0004-000000000004"), GradeId = grade2Id },
            new ItemGrade { ItemId = Guid.Parse("00000000-0000-0000-0004-000000000005"), GradeId = grade2Id },

            // Grade 3 Item linkages
            new ItemGrade { ItemId = Guid.Parse("00000000-0000-0000-0004-000000000031"), GradeId = grade3Id },
            new ItemGrade { ItemId = Guid.Parse("00000000-0000-0000-0004-000000000032"), GradeId = grade3Id },
            new ItemGrade { ItemId = Guid.Parse("00000000-0000-0000-0004-000000000033"), GradeId = grade3Id }
        );

        // Seed SchoolKits
        var kit1Id = Guid.Parse("00000000-0000-0000-0007-000000000001");
        var kit2Id = Guid.Parse("00000000-0000-0000-0007-000000000002");
        var kit3Id = Guid.Parse("00000000-0000-0000-0007-000000000003");

        modelBuilder.Entity<SchoolKit>().HasData(
            new SchoolKit { Id = kit1Id, Name = "Grade 1 Standard Kit", Description = "Essential textbooks and stationery bundle for Grade 1", GradeId = grade1Id, IsActive = true, CreatedAt = DateTime.UtcNow },
            new SchoolKit { Id = kit2Id, Name = "Grade 2 Premium Kit", Description = "Complete academic package including textbooks and journals for Grade 2", GradeId = grade2Id, IsActive = true, CreatedAt = DateTime.UtcNow },
            new SchoolKit { Id = kit3Id, Name = "Grade 3 Classic Kit", Description = "All required textbooks and school bag for Grade 3", GradeId = grade3Id, IsActive = true, CreatedAt = DateTime.UtcNow }
        );

        // Seed SchoolKitItems
        modelBuilder.Entity<SchoolKitItem>().HasData(
            // Grade 1 Kit Items
            new SchoolKitItem { SchoolKitId = kit1Id, ItemId = Guid.Parse("00000000-0000-0000-0004-000000000011"), Quantity = 1 },
            new SchoolKitItem { SchoolKitId = kit1Id, ItemId = Guid.Parse("00000000-0000-0000-0004-000000000012"), Quantity = 3 },
            new SchoolKitItem { SchoolKitId = kit1Id, ItemId = Guid.Parse("00000000-0000-0000-0004-000000000013"), Quantity = 1 },

            // Grade 2 Kit Items
            new SchoolKitItem { SchoolKitId = kit2Id, ItemId = Guid.Parse("00000000-0000-0000-0004-000000000001"), Quantity = 1 },
            new SchoolKitItem { SchoolKitId = kit2Id, ItemId = Guid.Parse("00000000-0000-0000-0004-000000000002"), Quantity = 2 },
            new SchoolKitItem { SchoolKitId = kit2Id, ItemId = Guid.Parse("00000000-0000-0000-0004-000000000003"), Quantity = 1 },
            new SchoolKitItem { SchoolKitId = kit2Id, ItemId = Guid.Parse("00000000-0000-0000-0004-000000000004"), Quantity = 1 },
            new SchoolKitItem { SchoolKitId = kit2Id, ItemId = Guid.Parse("00000000-0000-0000-0004-000000000005"), Quantity = 1 },

            // Grade 3 Kit Items
            new SchoolKitItem { SchoolKitId = kit3Id, ItemId = Guid.Parse("00000000-0000-0000-0004-000000000031"), Quantity = 1 },
            new SchoolKitItem { SchoolKitId = kit3Id, ItemId = Guid.Parse("00000000-0000-0000-0004-000000000032"), Quantity = 1 },
            new SchoolKitItem { SchoolKitId = kit3Id, ItemId = Guid.Parse("00000000-0000-0000-0004-000000000033"), Quantity = 1 }
        );
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var itemEntries = ChangeTracker.Entries<Item>();
        foreach (var entry in itemEntries)
        {
            if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
            {
                var item = entry.Entity;
                if (item.IsStockInitialized && item.TargetQty > 0 && item.StockQty == item.TargetQty)
                {
                    if (item.CompletedAt == null)
                    {
                        item.CompletedAt = DateTime.UtcNow;
                    }
                }
                else
                {
                    item.CompletedAt = null;
                }
            }
        }

        var entries = ChangeTracker.Entries<BaseEntity>();
        
        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Id = Guid.NewGuid();
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.IsDeleted = false;
                    break;

                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    break;

                case EntityState.Deleted:
                    // Soft delete logic
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    entry.Entity.DeletedAt = DateTime.UtcNow;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
