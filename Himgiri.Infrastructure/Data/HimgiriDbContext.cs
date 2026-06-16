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
            e.Property(x => x.HsnCode).HasMaxLength(20);
            e.Property(x => x.GstPercent).HasPrecision(5, 2);
            e.Property(x => x.CgstPercent).HasPrecision(5, 2);
            e.Property(x => x.SgstPercent).HasPrecision(5, 2);
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
            e.Property(x => x.SubTotal).HasPrecision(10, 2);
            e.Property(x => x.TotalGst).HasPrecision(10, 2);
            e.Property(x => x.DeliveryFee).HasPrecision(10, 2);
            e.Property(x => x.DeliveryGst).HasPrecision(10, 2);
            e.Property(x => x.GrandTotal).HasPrecision(10, 2);
            e.HasIndex(x => x.PaymentStatus);
            e.HasIndex(x => x.Status);
            e.HasIndex(x => x.CreatedAt);
            e.HasOne(x => x.Grade).WithMany().HasForeignKey(x => x.GradeId).OnDelete(DeleteBehavior.Restrict);
            e.HasIndex(x => x.GradeId);
        });

        // ── OrderItem ──
        modelBuilder.Entity<OrderItem>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.UnitPrice).HasPrecision(10, 2);
            e.Property(x => x.GstAmount).HasPrecision(10, 2);
            e.Property(x => x.Cgst).HasPrecision(10, 2);
            e.Property(x => x.Sgst).HasPrecision(10, 2);
            e.Property(x => x.LineTotal).HasPrecision(10, 2);
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

        // ── VendorSettings (single row) ──
        modelBuilder.Entity<VendorSettings>(e =>
        {
            e.HasKey(x => x.Id);
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
            e.HasOne(x => x.Order).WithMany().HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Cascade);
        });

        // ── SchoolKit ──
        modelBuilder.Entity<SchoolKit>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).IsRequired().HasMaxLength(200);
            e.HasOne(x => x.Grade).WithMany().HasForeignKey(x => x.GradeId).OnDelete(DeleteBehavior.Restrict);
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

        modelBuilder.Entity<ItemCategory>().HasData(
            new { Id = catTextbookId, Name = "Textbook", Description = "School Textbooks", HsnCode = "4901", GstPercent = 0m, CgstPercent = 0m, SgstPercent = 0m, IsTaxable = false, IsActive = true, IsDeleted = false, CreatedAt = DateTime.UtcNow, DisplayOrder = 1 },
            new { Id = catStationeryId, Name = "Stationery", Description = "School Stationery", HsnCode = "4820", GstPercent = 12m, CgstPercent = 6m, SgstPercent = 6m, IsTaxable = true, IsActive = true, IsDeleted = false, CreatedAt = DateTime.UtcNow, DisplayOrder = 2 },
            new { Id = catJournalId, Name = "Journal", Description = "School Journals", HsnCode = "4820", GstPercent = 12m, CgstPercent = 6m, SgstPercent = 6m, IsTaxable = true, IsActive = true, IsDeleted = false, CreatedAt = DateTime.UtcNow, DisplayOrder = 3 },
            new { Id = catBagId, Name = "Bag", Description = "School Bags", HsnCode = "4202", GstPercent = 18m, CgstPercent = 9m, SgstPercent = 9m, IsTaxable = true, IsActive = true, IsDeleted = false, CreatedAt = DateTime.UtcNow, DisplayOrder = 4 },
            new { Id = catDeliveryId, Name = "Delivery Fee", Description = "Delivery Charges", HsnCode = "9965", GstPercent = 18m, CgstPercent = 9m, SgstPercent = 9m, IsTaxable = true, IsActive = true, IsDeleted = false, CreatedAt = DateTime.UtcNow, DisplayOrder = 5 }
        );

        // Vendor Settings
        modelBuilder.Entity<VendorSettings>().HasData(
            new VendorSettings { Id = Guid.Parse("00000000-0000-0000-0003-000000000001"), CompanyName = "Himgiri Goods Pvt. Ltd", Gstin = "PENDING_FROM_CLIENT", Address = "Hinjawadi, Pune, Maharashtra", ContactEmail = "support@himgirigoods.com", ContactPhone = "PENDING_FROM_CLIENT", InvoicePrefix = "HG", LastInvoiceNumber = 0, CreatedAt = DateTime.UtcNow }
        );

        // Sample Items linked to Category
        modelBuilder.Entity<Item>().HasData(
            new Item { Id = Guid.Parse("00000000-0000-0000-0004-000000000001"), Name = "Almanac 2026-27", Description = "DPS Hinjawadi School Almanac", ImageUrl = "https://picsum.photos/200/300?random=1", Price = 150, PurchasePrice = 100, Mrp = 180, CategoryId = catJournalId, Unit = "Pieces (Pcs)", IsStockInitialized = true, CreatedAt = DateTime.UtcNow },
            new Item { Id = Guid.Parse("00000000-0000-0000-0004-000000000002"), Name = "Portfolio File", Description = "DPS Hinjawadi Portfolio File", ImageUrl = "https://picsum.photos/200/300?random=2", Price = 80, PurchasePrice = 50, Mrp = 90, CategoryId = catStationeryId, Unit = "Pieces (Pcs)", IsStockInitialized = true, CreatedAt = DateTime.UtcNow },
            new Item { Id = Guid.Parse("00000000-0000-0000-0004-000000000003"), Name = "Public Speaking Journal", Description = "DPS Public Speaking Journal", ImageUrl = "https://picsum.photos/200/300?random=3", Price = 120, PurchasePrice = 80, Mrp = 140, CategoryId = catJournalId, Unit = "Pieces (Pcs)", IsStockInitialized = true, CreatedAt = DateTime.UtcNow },
            new Item { Id = Guid.Parse("00000000-0000-0000-0004-000000000004"), Name = "Majet Shikuya Marathi", Description = "Marathi Theme Book", ImageUrl = "https://picsum.photos/200/300?random=4", Price = 90, PurchasePrice = 60, Mrp = 100, CategoryId = catTextbookId, Unit = "Pieces (Pcs)", IsStockInitialized = true, CreatedAt = DateTime.UtcNow },
            new Item { Id = Guid.Parse("00000000-0000-0000-0004-000000000005"), Name = "Theme Book Grade 2", Description = "Grade 2 Theme Book", ImageUrl = "https://picsum.photos/200/300?random=5", Price = 110, PurchasePrice = 75, Mrp = 130, CategoryId = catTextbookId, Unit = "Pieces (Pcs)", IsStockInitialized = true, CreatedAt = DateTime.UtcNow }
        );

        // Seed ItemGrades Many-to-Many relations
        modelBuilder.Entity<ItemGrade>().HasData(
            new ItemGrade { ItemId = Guid.Parse("00000000-0000-0000-0004-000000000001"), GradeId = grade2Id },
            new ItemGrade { ItemId = Guid.Parse("00000000-0000-0000-0004-000000000002"), GradeId = grade2Id },
            new ItemGrade { ItemId = Guid.Parse("00000000-0000-0000-0004-000000000003"), GradeId = grade2Id },
            new ItemGrade { ItemId = Guid.Parse("00000000-0000-0000-0004-000000000004"), GradeId = grade2Id },
            new ItemGrade { ItemId = Guid.Parse("00000000-0000-0000-0004-000000000005"), GradeId = grade2Id }
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
