using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BusShuttleMVC.Data;
using System.Security.Claims;
using BusShuttleMVC.Services;
using DomainModel;
namespace BusShuttleMVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        builder.Services.AddScoped<IBusService, BusService>();
        builder.Services.AddScoped<IBusStopService, BusStopService>();
        builder.Services.AddScoped<IBusLoopService, BusLoopService>();
        builder.Services.AddScoped<IBusRouteService, BusRouteService>();
        builder.Services.AddScoped<IEntryService, EntryService>();
        builder.Services.AddDbContext<ApplicationDbContext>();

        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();
        builder.Services.AddControllersWithViews();

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("IsDriver", policy => policy.RequireClaim("isDriver", "true"));
            options.AddPolicy("IsManager", policy => policy.RequireClaim("isManager", "true")); // new policy
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        app.Run();

    }
}

