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
    public DbSet<MerchantPayout> MerchantPayouts { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<MerchantWallet> MerchantWallets { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<BranchReview> BranchReviews { get ; set; }
    public DbSet<ProductBundle> ProductBundles{ get; set; }
    public DbSet<ProductBundleImage> ProductBundleImages { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<BundleAssignee> GetBundleAssignees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

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
        modelBuilder.Entity<MerchantPayout>()
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
        modelBuilder.Entity<ProductBundle>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<ProductBundleImage>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<User>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        #endregion
    }
}
