using GPACStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GPACStore.Data
{
    public class DataContext:DbContext
    {
        string dbName = "EcommerceDatabase.db";

        //Issue: stackoverflow.com/questions/36488461/sqlite-in-asp-net-core-with-entityframeworkcore
        //Added DataContext to Startup Class Constructor & ConfigureServices
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Filename=EcommerceDatabase.db");

            //Issue: kontext.tech/column/dotnet_framework/275/sqlite-in-net-core-with-entity-framework-core
            optionsBuilder.UseSqlite("Filename=" + dbName + "", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<Product>().ToTable("Products", "test");
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.productName); //.IsUnique()
                entity.Property(e => e.ProductPrice);
                entity.Property(e => e.ArrivalDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
