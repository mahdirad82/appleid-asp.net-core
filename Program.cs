using AppleAccounts.Data;
using AppleAccounts.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace AppleAccounts;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Add DbContext configuration
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseMySql(builder.Configuration.GetConnectionString("Default")
            , new MySqlServerVersion(new Version(8, 1, 0)));
        });

        builder.Services.AddScoped<IAppleIdService, AppleIdService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=AppleId}/{action=Index}/{id?}");

        app.Run();
    }
}
