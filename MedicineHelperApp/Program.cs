using MedicineHelper.Business.ServicesImplementations;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.Data.Abstractions.Repositories;
using MedicineHelper.Data.Repositories;
using MedicineHelper.DataBase;
using MedicineHelper.DataBase.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Serilog;
using Serilog.Events;
using System.Reflection;
using System.Text;

namespace MedicineHelperApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((ctx, lc) => lc
                .WriteTo.Console()
                .WriteTo.File(GetPathToLogFile(),
                    LogEventLevel.Information));

            //Connection Db
            var connectionString = builder.Configuration.GetConnectionString(name: "Default");
            builder.Services.AddDbContext<MedicineHelperContext>(optionsBuilder =>
            optionsBuilder.UseSqlServer(connectionString));

            // Add services to the container.

            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services
               .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.ExpireTimeSpan = TimeSpan.FromHours(1);
                   options.LoginPath = new PathString(@"/Account/Login");
                   options.LogoutPath = new PathString(@"/Account/Logout");
                   options.AccessDeniedPath = new PathString(@"/Account/Login");
               });

            builder.Services.AddHttpContextAccessor();
            builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            // Add business services
            builder.Services.AddScoped<IClinicService, ClinicService>();
            builder.Services.AddScoped<IConclusionService, ConclusionService>();
            builder.Services.AddScoped<IDiseaseHistoryService, DiseaseHistoryService>();
            builder.Services.AddScoped<IDoctorService, DoctorService>();
            builder.Services.AddScoped<IDoctorVisitService, DoctorVisitService>();
            builder.Services.AddScoped<IFluorographyService, FluorographyService>();
            builder.Services.AddScoped<IMedicinePrescriptionService, MedicinePrescriptionService>();
            builder.Services.AddScoped<IMedicineProcedureService, MedicineProcedureService>();
            builder.Services.AddScoped<IMedicineService, MedicineService>();
            builder.Services.AddScoped<IMedicineÑheckupService, MedicineÑheckupService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IVaccinationService, VaccinationService>();

            // Add repositories
            builder.Services.AddScoped<IRepository<Conclusion>, Repository<Conclusion>>();
            builder.Services.AddScoped<IRepository<Appointment>, Repository<Appointment>>();
            builder.Services.AddScoped<IRepository<Disease>, Repository<Disease>>();
            builder.Services.AddScoped<IRepository<Doctor>, Repository<Doctor>>();
            builder.Services.AddScoped<IRepository<DoctorVisit>, Repository<DoctorVisit>>();
            builder.Services.AddScoped<IRepository<Fluorography>, Repository<Fluorography>>();
            builder.Services.AddScoped<IRepository<MedicineÑheckup>, Repository<MedicineÑheckup>>();
            builder.Services.AddScoped<IRepository<Clinic>, Repository<Clinic>>();
            builder.Services.AddScoped<IRepository<Medicine>, Repository<Medicine>>();
            builder.Services.AddScoped<IRepository<MedicineProcedure>, Repository<MedicineProcedure>>();
            builder.Services.AddScoped<IRepository<MedicinePrescription>, Repository<MedicinePrescription>>();
            builder.Services.AddScoped<IRepository<DiseaseHistory>, Repository<DiseaseHistory>>();
            builder.Services.AddScoped<IRepository<Vaccination>, Repository<Vaccination>>();
            builder.Services.AddScoped<IRepository<User>, Repository<User>>();
            builder.Services.AddScoped<IRepository<Role>, Repository<Role>>();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "Login",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            app.MapControllerRoute(
                name: "admin",
                pattern: "{controller=Admin}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
        private static string GetPathToLogFile()
        {
            var sb = new StringBuilder();
            sb.Append(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            sb.Append(@"\logs\");
            sb.Append($"{DateTime.Now:yyyyMMddhhmmss}");
            sb.Append("data.log");
            return sb.ToString();
        }
    }
}