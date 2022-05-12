
using BLL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ShopContext : IdentityDbContext<User>
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();
        public DbSet<ProductType> ProductTypes => Set<ProductType>();
        public DbSet<Check> Checks => Set<Check>();
        public DbSet<Discount> Discounts => Set<Discount>();
        public DbSet<BonusCard> BonusCards => Set<BonusCard>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
        public DbSet<Supply> Supplies => Set<Supply>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckForProduct>()
                .HasKey(u => new { u.CheckId, u.ProductId });

            modelBuilder.Entity<CheckForProduct>()
            .HasOne(pt => pt.Check)
            .WithMany(p => p.CheckForProducts)
            .HasForeignKey(pt => pt.CheckId);

            modelBuilder.Entity<CheckForProduct>()
                .HasOne(pt => pt.Product)
                .WithMany(t => t.CheckForProducts)
                .HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<SupplyForProduct>()
            .HasKey(u => new { u.SupplyId, u.ProductId });

            modelBuilder.Entity<SupplyForProduct>()
            .HasOne(pt => pt.Supply)
            .WithMany(p => p.SupplyForProducts)
            .HasForeignKey(pt => pt.SupplyId);

            modelBuilder.Entity<SupplyForProduct>()
                .HasOne(pt => pt.Product)
                .WithMany(t => t.SupplyForProducts)
                .HasForeignKey(pt => pt.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
