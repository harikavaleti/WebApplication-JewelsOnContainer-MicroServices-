using Microsoft.EntityFrameworkCore;
using ProductCatalogApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogApi.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogBrand>(e =>
            {
                e.ToTable("CatalogBrands");

                e.Property(b => b.Id).IsRequired().UseHiLo("catalog_brand_hilo");

                e.Property(b => b.Brand).IsRequired().HasMaxLength(100);

            });

            modelBuilder.Entity<CatalogType>(e =>
            {
                e.ToTable("CatalogTypes");

                e.Property(b => b.Id).IsRequired().UseHiLo("catalog_type_hilo");

                e.Property(b => b.Type).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<CatalogItem>(e =>
            {
                e.ToTable("Catalog");

                e.Property(b => b.Id).IsRequired().UseHiLo("catalog_hilo");

                e.Property(b => b.Name).IsRequired().HasMaxLength(100);

                e.Property(b => b.Price).IsRequired();

                e.HasOne(b => b.CatalogType).WithMany().HasForeignKey(b => b.CatalogTypeId);

                e.HasOne(b => b.CatalogBrand).WithMany().HasForeignKey(b => b.CatalogBrandId);


            });

        }

    }
}
