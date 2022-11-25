
using MedicineHelper.Business.ServicesImplementations;
using MedicineHelper.Core.Abstractions;
using MedicineHelper.Data.Abstractions.Repositories;
using MedicineHelper.Data.Abstractions;
using MedicineHelper.DataBase;
using MedicineHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using MedicineHelper.Data.Repositories;
using Serilog;
using System.Reflection;
using System.Text;
using Serilog.Events;

namespace MedicineHelperWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Serilog
            builder.Host.UseSerilog((ctx, lc) => lc
                .WriteTo.Console()
                .WriteTo.File(GetPathToLogFile(),
                    LogEventLevel.Information));

            //Connection Db
            var connectionString = builder.Configuration.GetConnectionString(name: "Default");
            builder.Services.AddDbContext<MedicineHelperContext>(optionsBuilder =>
            optionsBuilder.UseSqlServer(connectionString));

            // Add services to the container.

            // Add automapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                option.IncludeXmlComments(builder.Configuration["XmlComments"]);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

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