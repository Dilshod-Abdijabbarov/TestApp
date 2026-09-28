
using Domain.Entities;
using Domain.Entities.Companies;
using Domain.Entities.Orders;
using Domain.Entities.Products;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using SaveEat.Domain.Entities;

namespace Infrastructure.DbContexts;

public class SaveEatDbContext : DbContext
{
    public SaveEatDbContext(DbContextOptions<SaveEatDbContext> options)
        : base(options)
    {
    }

    public DbSet<Company> Merchants { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<EmployeeInvite> EmployeeInvites { get; set; }
    public DbSet<CompanyPayout> MerchantPayouts { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<CompanyWallet> MerchantWallets { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<BranchReview> BranchReviews { get; set; }
    public DbSet<Set> Sets { get; set; }
    public DbSet<FileModel> FileModels { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<SetAssignee> SetAssignees { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<OrderItemProduct> OrderItemProducts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<OrderItem>()
        .HasCheckConstraint(
        "CK_OrderItem_ProductOrSet",
        "(product_id IS NOT NULL AND set_id IS NULL) OR (product_id IS NULL AND set_id IS NOT NULL)");


        // Yo Product, yo Set — ikkalasi bir vaqtda bo'lmasin, ikkalasi ham bo'sh bo'lmasin
        modelBuilder.Entity<Favorite>()
            .HasCheckConstraint(
                "CK_Favorite_ProductOrSet",
                "(product_id IS NOT NULL AND set_id IS NULL) OR (product_id IS NULL AND set_id IS NOT NULL)"
            );

        // Bitta foydalanuvchi bitta mahsulotni faqat bir marta yoqtira olsin (dublikat oldini olish)
        modelBuilder.Entity<Favorite>()
            .HasIndex(f => new { f.UserId, f.ProductId })
            .IsUnique()
            .HasFilter("product_id IS NOT NULL");

        modelBuilder.Entity<Favorite>()
            .HasIndex(f => new { f.UserId, f.SetId })
            .IsUnique()
            .HasFilter("set_id IS NOT NULL");

        // Delete behavior
        modelBuilder.Entity<Favorite>()
            .HasOne(f => f.User)
            .WithMany()
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);   // User o'chsa, sevimlilari ham o'chsin

        modelBuilder.Entity<Favorite>()
            .HasOne(f => f.Product)
            .WithMany()
            .HasForeignKey(f => f.ProductId)
            .OnDelete(DeleteBehavior.Cascade);   // Product o'chsa, sevimlidan ham o'chsin

        modelBuilder.Entity<Favorite>()
            .HasOne(f => f.Set)
            .WithMany()
            .HasForeignKey(f => f.SetId)
            .OnDelete(DeleteBehavior.Cascade);

        #region  Sequential GUID  vaqtga asoslangan, ya’ni har keyingi yaratilgani oldingisidan kattaroq bo‘lgan GUID yaratadi.
        modelBuilder.Entity<BaseEntity>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        #endregion
    }
}
