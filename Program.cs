using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ASP.NET.Services.Interfaces;
using ASP.NET.Services;
using ASP.NET.Data;
using ASP.NET.Data.Interfaces;
using ASP.NET.Data.Repository;
using Microsoft.AspNetCore.Cors.Infrastructure;

public class Program
{
 
    public static void Main(string[] args)
    {

        var host = CreateHostBuilder(args).Build();

        host.Run();

    static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
            webBuilder.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            });
        });
    }
}

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }


    public void ConfigureServices(IServiceCollection services)
    {
    // Register the DbContext with MySQL connection string
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21))));

    // Register services (business logic layer)
    services.AddScoped<IProductService, ProductService>();
    services.AddScoped<IOrderService, OrderService>();
/*     services.AddScoped<IUserService, UserService>();
    services.AddScoped<IOrderItemService, OrderItemService>(); */

    // Additional services from image
   /*  services.AddScoped<ICartService, CartService>();
    services.AddScoped<ICategoryService, CategoryService>(); */
/*     services.AddScoped<IReviewService, ReviewService>(); */

    // Register repositories (data access layer)
    services.AddScoped<IProductRepository, ProductRepository>();
    services.AddScoped<IOrderRepository, OrderRepository>();
/*     services.AddScoped<IOrderItemRepository, OrderItemRepository>();
    services.AddScoped<IUserRepository, UserRepository>(); */

    // Additional repositories from image
    services.AddScoped<ICartRepository, CartRepository>();
    services.AddScoped<ICategoryRepository, CategoryRepository>();
    services.AddScoped<IReviewRepository, ReviewRepository>();

    // Add controllers and views
    services.AddControllersWithViews();
    }


   public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();

    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    });
}
}
