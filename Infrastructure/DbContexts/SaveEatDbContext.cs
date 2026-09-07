using Microsoft.EntityFrameworkCore;
using SaveEat.Domain.Entities;

namespace Infrastructure.DbContexts;

public class SaveEatDbContext : DbContext
{
    public SaveEatDbContext(DbContextOptions<SaveEatDbContext> options)
        : base(options)
    {
    }

    public DbSet<Merchant> Merchants { get; set; }
    public DbSet<MerchantBranch> MerchantBranches { get; set; }
    public DbSet<MerchantInvite> MerchantInvites { get; set; }
    public DbSet<MerchantSettlement> MerchantSettlements { get; set; }
    public DbSet<MerchantUser> MerchantUsers { get; set; }
    public DbSet<MerchantWallet> MerchantWallets { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<SurpriseBag> SurpriseBags { get; set; }
    public DbSet<SurpriseBagImage> SurpriseBagImages { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<BagAssignee> BagAssignees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        #region  Sequential GUID  vaqtga asoslangan, ya’ni har keyingi yaratilgani oldingisidan kattaroq bo‘lgan GUID yaratadi.
        modelBuilder.Entity<Merchant>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<MerchantBranch>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<MerchantInvite>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<MerchantBranch>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<MerchantSettlement>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<Order>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<Payment>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<Review>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();

        modelBuilder.Entity<SurpriseBag>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<SurpriseBagImage>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        modelBuilder.Entity<User>()
            .Property(e => e.Id)
            .HasValueGenerator<Microsoft.EntityFrameworkCore.ValueGeneration.SequentialGuidValueGenerator>();
        #endregion
    }
}
