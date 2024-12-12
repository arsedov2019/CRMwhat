using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        // Определение таблиц (DbSet)
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Конфигурация для таблицы Courier
            modelBuilder.Entity<Courier>().HasKey(c => c.Id);
            modelBuilder.Entity<Courier>().Property(c => c.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Courier>().Property(c => c.PhoneNumber).IsRequired().HasMaxLength(15);

            // Конфигурация для таблицы Customer
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(c => c.PhoneNumber).IsRequired().HasMaxLength(15);

            // Конфигурация для таблицы Order
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Order>().Property(o => o.Status).IsRequired();
            modelBuilder.Entity<Order>().HasMany(o => o.Items).WithOne().HasForeignKey("OrderId");

            // Конфигурация для таблицы Product
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired().HasColumnType("decimal(10,2)");
        }
    }
}
