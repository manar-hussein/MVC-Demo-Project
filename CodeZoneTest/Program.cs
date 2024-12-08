using CodeZoneTest.Data;
using CodeZoneTest.Helper;
using Microsoft.EntityFrameworkCore;
namespace CodeZoneTest;
public class Program
{
    public static async  Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<AppDbContext>(option =>
        {
            option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        builder.Services.RgisterAppServices();
        var app = builder.Build();
        // Update DataBase
        using var scope = app.Services.CreateScope();
        var service = scope.ServiceProvider;
        var dbContext = service.GetRequiredService<AppDbContext>();
        var loggerFactory = service.GetRequiredService<ILoggerFactory>();
        try
        {
            await dbContext.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogError(ex, $"Error Occured During Apply The Migration : {ex.InnerException}");
        }
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
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
            pattern: "{controller=Store}/{action=Index}/{id?}");

        app.Run();
    }
}