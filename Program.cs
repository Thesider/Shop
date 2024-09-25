using Microsoft.EntityFrameworkCore;
using ASP.NET.Services.Interfaces;
using ASP.NET.Services;
using ASP.NET.Data;
using ASP.NET.Data.Interfaces;
using ASP.NET.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21)),
    mySqlOptions => mySqlOptions.EnableRetryOnFailure(
        maxRetryCount: 5, 
        maxRetryDelay: TimeSpan.FromSeconds(5), 
        errorNumbersToAdd: null
    )));

// Register services (business logic layer)
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Register repositories (data access layer)
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Add controllers and views with custom view locations
builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        options.ViewLocationFormats.Add("Web/Views/{1}/{0}.cshtml");
        options.ViewLocationFormats.Add("Web/Views/Shared/{0}.cshtml");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
