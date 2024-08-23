using Ecommerace.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ecommerace.Areas.Admin.ViewModels;

namespace Ecommerace.Models
{
    public class MVCECommeraceContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Coupon> Coupon { get; set; }

        public DbSet<OrderCoupon> OrderCoupon { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<Skus> Skus { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders{ get; set;}

        public DbSet<Country> Country { get; set; }

        public DbSet<State> State { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<UserAddress> UserAddress { get; set; }

        public DbSet<ShippingMethods> ShippingMethods { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }

        public DbSet<ProductAttributes> Attributes { get; set; }

        public DbSet<AttributesOptions> AttributesOptions { get; set; }

        public DbSet<AttributeOptionSku> AttributeOptionSku { get; set; }

        public DbSet<SkuMedia> SkuMedia { get; set; }

        public MVCECommeraceContext() : base() { }

        public MVCECommeraceContext(DbContextOptions<MVCECommeraceContext> options) : base(options){
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-COJ84P3\\SQLEXPRESS;Database=MVCECommerace;Trusted_Connection=True;Encrypt=False;");
            base.OnConfiguring(optionsBuilder);
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
               .HasOne(c => c.Parent)
               .WithMany()
               .HasForeignKey(c => c.Parent_Id)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.SubCategories)
                .WithOne(c => c.Parent)
                .HasForeignKey(c => c.Parent_Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Client)
                .WithMany(u => u.ClientOrders)
                .HasForeignKey(o => o.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Products>()
                .HasOne(o => o.Store)
                .WithMany(u => u.StoreProducts)
                .HasForeignKey(o => o.StoreId)
                .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<ShippingMethods>().HasData
            //    (new ShippingMethods
            //    {
            //        Id = 1,
            //        Name = "Product 1",
            //        Description = "Description for product 1",
            //        Cost = 10.99,
            //        EstimatedDeliveryTime = 5,
            //        CreatedAt = DateTime.Now.AddDays(-10),
            //        UpdatedAt = DateTime.Now
            //    },
            //    new ShippingMethods
            //    {
            //        Id = 2,
            //        Name = "Product 2",
            //        Description = "Description for product 2",
            //        Cost = 20.99,
            //        EstimatedDeliveryTime = 3,
            //        CreatedAt = DateTime.Now.AddDays(-20),
            //        UpdatedAt = DateTime.Now
            //    },
            //    new ShippingMethods
            //    {
            //        Id = 3,
            //        Name = "Product 3",
            //        Description = "Description for product 3",
            //        Cost = 30.99,
            //        EstimatedDeliveryTime = 7,
            //        CreatedAt = DateTime.Now.AddDays(-30),
            //        UpdatedAt = DateTime.Now
            //    },
            //    new ShippingMethods
            //    {
            //        Id = 4,
            //        Name = "Product 4",
            //        Description = "Description for product 4",
            //        Cost = 40.99,
            //        EstimatedDeliveryTime = 4,
            //        CreatedAt = DateTime.Now.AddDays(-40),
            //        UpdatedAt = DateTime.Now
            //    },
            //    new ShippingMethods
            //    {
            //        Id = 5,
            //        Name = "Product 5",
            //        Description = "Description for product 5",
            //        Cost = 50.99,
            //        EstimatedDeliveryTime = 6,
            //        CreatedAt = DateTime.Now.AddDays(-50),
            //        UpdatedAt = DateTime.Now
            //    },
            //    new ShippingMethods
            //    {
            //        Id = 6,
            //        Name = "Product 6",
            //        Description = "Description for product 6",
            //        Cost = 60.99,
            //        EstimatedDeliveryTime = 2,
            //        CreatedAt = DateTime.Now.AddDays(-60),
            //        UpdatedAt = DateTime.Now
            //    },
            //    new ShippingMethods
            //    {
            //        Id = 7,
            //        Name = "Product 7",
            //        Description = "Description for product 7",
            //        Cost = 70.99,
            //        EstimatedDeliveryTime = 8,
            //        CreatedAt = DateTime.Now.AddDays(-70),
            //        UpdatedAt = DateTime.Now
            //    },
            //    new ShippingMethods
            //    {
            //        Id = 8,
            //        Name = "Product 8",
            //        Description = "Description for product 8",
            //        Cost = 80.99,
            //        EstimatedDeliveryTime = 1,
            //        CreatedAt = DateTime.Now.AddDays(-80),
            //        UpdatedAt = DateTime.Now
            //    });

            //modelBuilder.Entity<Products>().HasData(
            //    new Products() { Id = 1, Name = "IPhone", CategoryId = 1, Description = "Mobile phone created by Apple", Slug = "sss", Price = 1000m, StoreId = 1, CreatedAt = new DateTime(2024, 05, 25, 09, 15, 00), UpdatedAt = new DateTime(2024, 07, 25, 07, 00, 00) },
            //    new Products() { Id = 2, Name = "Air pods", CategoryId = 2, Description = "created by Apple", Slug = "aaa", Price = 500, StoreId = 2, CreatedAt = new DateTime(2024, 05, 25, 09, 15, 00), UpdatedAt = new DateTime(2024, 07, 25, 07, 00, 00) },
            //    new Products() { Id = 3, Name = "LabTop Mac", CategoryId = 3, Description = "Laptop created by Apple", Slug = "jjj", Price = 3000, StoreId = 3, CreatedAt = new DateTime(2024, 05, 25, 09, 15, 00), UpdatedAt = new DateTime(2024, 07, 25, 07, 00, 00) },
            //    new Products() { Id = 4, Name = "Book", CategoryId = 4, Description = "regular book about bla bla ", Slug = "fff", Price = 100, StoreId = 4, CreatedAt = new DateTime(2024, 05, 25, 09, 15, 00), UpdatedAt = new DateTime(2024, 07, 25, 07, 00, 00) }
            //);

            //modelBuilder.Entity<Skus>().HasData(
            //    new Skus() { Id = 1, Code = "ssfgc342", ProductsId = 1, CreatedAt = new DateTime(2024, 07, 22), UpdatedAt = new DateTime(2024, 08, 1) },
            //    new Skus() { Id = 2, Code = "ssfgc342", ProductsId = 3, CreatedAt = new DateTime(2024, 07, 22), UpdatedAt = new DateTime(2024, 08, 1) },
            //    new Skus() { Id = 3, Code = "ssfgc342", ProductsId = 4, CreatedAt = new DateTime(2024, 07, 22), UpdatedAt = new DateTime(2024, 08, 1) }
            //);
            base.OnModelCreating(modelBuilder);
        }



    }
}

