using MedicineHelper.Business.ServiceImplemintations;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.DataBase;
using Microsoft.EntityFrameworkCore;

namespace MedicineHelperApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            

            var connectionString = "Server=DESKTOP-P99SU78;Database=MedicineHelperDataBase;Trusted_Connection=True;";
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient <IVisitsService, VisitsService> ();
            builder.Services.AddSingleton<VisitsStorage>();

            builder.Services.AddDbContext<MedicineHelperContext>(optionsBuilder =>
            optionsBuilder.UseSqlServer(connectionString));

            var app = builder.Build();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}