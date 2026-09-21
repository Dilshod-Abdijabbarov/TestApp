using Domain.Entities;
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

        #region  Sequential GUID  vaqtga asoslangan, ya’ni har keyingi yaratilgani oldingisidan kattaroq bo‘lgan GUID yaratadi.
        modelBuilder.Entity<Company>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<Branch>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<EmployeeInvite>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<Branch>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<CompanyPayout>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<Order>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<Payment>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<BranchReview>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<Basket>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<FileModel>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<User>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        #endregion
    }
}
