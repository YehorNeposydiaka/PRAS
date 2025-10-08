using Microsoft.EntityFrameworkCore; // уже есть
using Microsoft.EntityFrameworkCore.Design; // уже есть



namespace Pras.Models
{
    public class AppDbContext : DbContext
    {
        // === Таблицы ===
        public DbSet<Base> Bases { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<CheckProducts> CheckProducts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        // === Конструктор ===
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // === Фабрика для миграций ===
        public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseSqlite("Data Source=Pras.db"); // SQLite
                return new AppDbContext(optionsBuilder.Options);
            }
        }

        // === Конфигурация подключения (на случай, если DbContext создают вручную) ===
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source=Pras.db");
        }

        // === Конфигурация модели ===
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // === Base (1 -> many Products, Checks, Invoices) ===
            modelBuilder.Entity<Base>()
                .HasMany(b => b.Products)
                .WithOne(p => p.Base)
                .HasForeignKey(p => p.BaseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Base>()
                .HasMany(b => b.Checks)
                .WithOne(c => c.Base)
                .HasForeignKey(c => c.BaseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Base>()
                .HasMany(b => b.Invoices)
                .WithOne(i => i.Base)
                .HasForeignKey(i => i.BaseId)
                .OnDelete(DeleteBehavior.Cascade);

            // === User (1 -> many Checks) ===
            modelBuilder.Entity<User>()
                .HasMany(u => u.Checks)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // === CheckProducts (many-to-many) ===
            modelBuilder.Entity<CheckProducts>()
                .HasOne(cp => cp.Check)
                .WithMany(c => c.CheckProducts)
                .HasForeignKey(cp => cp.CheckId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CheckProducts>()
                .HasOne(cp => cp.Product)
                .WithMany(p => p.CheckProducts)
                .HasForeignKey(cp => cp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // === Первичные ключи ===
            modelBuilder.Entity<Base>().HasKey(b => b.Id);
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Check>().HasKey(c => c.Id);
            modelBuilder.Entity<CheckProducts>().HasKey(cp => cp.Id);
            modelBuilder.Entity<Invoice>().HasKey(i => i.Id);

            // === Индексы ===
            modelBuilder.Entity<Product>().HasIndex(p => p.Code).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Base>().HasIndex(b => b.Email).IsUnique();

            // === Seed данных ===
            modelBuilder.Entity<Base>().HasData(
                new Base { Id = 1, Email = "main@pras.com", Password = "12345", CreatedAt = new DateTime(2025, 10, 8, 19, 45, 30), Status = 1 }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin", Email = "admin@pras.com", Password = "admin" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Product A", Code = 111222333, BaseId = 1 },
                new Product { Id = 2, Name = "Product B", Code = 333222, BaseId = 1 }
            );

            modelBuilder.Entity<Invoice>().HasData(
                new Invoice { Id = 1, BaseId = 1, DocumentNumber = "INV-001", SupplierName = "Supplier X", InvoiceDate = new DateTime(2025, 10, 8, 19, 45, 30) }
            );

            modelBuilder.Entity<Check>().HasData(
                new Check { Id = 1, BaseId = 1, UserId = 1, Number = "CHK-001", PaymentType = "Cash" }
            );

            modelBuilder.Entity<CheckProducts>().HasData(
                new CheckProducts { Id = 1, CheckId = 1, ProductId = 1 },
                new CheckProducts { Id = 2, CheckId = 1, ProductId = 2 }
            );
        }
    }
}
