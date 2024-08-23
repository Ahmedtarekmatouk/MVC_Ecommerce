using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Ecommerace.Models;
using Ecommerace.Repositories;
using Ecommerace.Repositories.Categories;
using Ecommerace.Repositories.Coupons;
using Ecommerace.Services.Categories;
using Ecommerace.Services.Coupons;
using Ecommerace.Repositories.ShippingMethod;
using Ecommerace.Services.ShippingMethod;
using Ecommerace.Repositories.Product;
using Ecommerace.Services.Product;
using Ecommerace.Services;
using Ecommerace.Services.Orders;
using Ecommerace.Repositories.Orders;
using Ecommerace.Services.Admin;
using Ecommerace.Repositories.Clients;
using Ecommerace.Seeders;
using Ecommerace.Services.Clients;
using Ecommerace.Services.Site;
using Ecommerace.Services.Store;

namespace Ecommerace;

public class Program
{
    public IConfiguration Configuration { get; }

    public Program(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<MVCECommeraceContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 4;
            options.Password.RequireLowercase = false;
        })
          .AddEntityFrameworkStores<MVCECommeraceContext>()
          .AddDefaultTokenProviders();



        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IRepository<Order>, OrderRepository>();

        builder.Services.AddScoped<IStoreService, StoreService>();


        builder.Services.AddDbContext<MVCECommeraceContext>(option =>
        {
            option.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
        });

        #region resolve repositories
        builder.Services.AddScoped<ICouponRepository, CouponRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IShippingMethodsRepository, ShippingMethodsRepository>();
        builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
        builder.Services.AddScoped<ISkusRepository, SkusRepository>();
        builder.Services.AddScoped<IRepository<Order>, OrderRepository>();
        builder.Services.AddScoped<IClientsRepository, ClientsRepository>();

        #endregion

        #region resolve services
        builder.Services.AddScoped<ICouponService, CouponService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IShippingMethodsService, ShippingMethodsService>();
        builder.Services.AddScoped<IProductsService, ProductsService>();
        builder.Services.AddScoped<ISkusService, SkusService>();

        builder.Services.AddScoped<IAdminService, AdminService>();
        builder.Services.AddScoped<IOrderService, OrderService>();

        builder.Services.AddScoped<IClientsService, ClientsService>();
        builder.Services.AddScoped<ICategoriesService, CategoriesService>();

        #endregion

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        // Add area routing
        app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "Admin",
            pattern: "admin/{controller=Home}/{action=Index}/{id?}");


        app.MapControllerRoute(
            name: "Store",
            pattern: "Store/{controller=Home}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Site}/{action=Index}/{id?}");

        #region site routes
        app.MapControllerRoute(
            name: "Shop",
            defaults: new { controller = "Site", action = "Shop" },
            pattern: "shop");

        app.MapControllerRoute(
            name: "Cart",
            defaults: new { controller = "Site", action = "Cart" },
            pattern: "cart");

        app.MapControllerRoute(
            name: "Checkout",
            defaults: new { controller = "Site", action = "Checkout" },
            pattern: "checkout");
        
        app.MapControllerRoute(
            name: "Detail",
            defaults: new { controller = "Site", action = "Detail" },
            pattern: "detail");

        app.MapControllerRoute(
            name: "Contact",
            defaults: new { controller = "Site", action = "Contact" },
            pattern: "contact");

        #endregion


        var scope = app.Services.CreateScope();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    //    DatabaseSeeder.Run(roleManager, userManager);

        //CountriesSeeder countriesSeeder = new CountriesSeeder();
        //countriesSeeder.Run();
        app.Run();
    }
}
