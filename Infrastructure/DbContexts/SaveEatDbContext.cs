using Microsoft.EntityFrameworkCore;
using SaveEat.Domain.Entities;

namespace Infrastructure.DbContexts;

public class SaveEatDbContext : DbContext
{
    public SaveEatDbContext(DbContextOptions<SaveEatDbContext> options)
        : base(options)
    {
    }

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
