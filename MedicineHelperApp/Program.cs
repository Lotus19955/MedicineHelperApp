using MedicineHelper.Business.ServiceImplemintations;
using MedicineHelper.Core;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.Data.Abstractions.Repository;
using MedicineHelper.Data.Repositories;
using MedicineHelper.Data.Repositories.Repository;
using MedicineHelper.DataBase;
using MedicineHelper.DataBase.Entites;
using Microsoft.EntityFrameworkCore;

namespace MedicineHelperApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString(name: "Default");
            builder.Services.AddDbContext<MedicineHelperContext>(optionsBuilder =>
            optionsBuilder.UseSqlServer(connectionString));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped<IVisitsService, VisitsService> ();
            builder.Services.AddScoped<IVaccinationService, VaccinationService>();
            builder.Services.AddScoped<IAdditionalVisitRepository, VisitGenericRepository>();
            builder.Services.AddScoped<IRepository<Vaccination>, Repository<Vaccination>>();
            builder.Services.AddScoped<IVisitRepository, VisitRepository>();
            builder.Services.AddScoped<IVaccinationRepository, VaccinationRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Configuration.AddJsonFile("secrets.json");

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