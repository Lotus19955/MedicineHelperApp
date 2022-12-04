
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
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MedicineHelperWebAPI.Utils;

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

            builder.Services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(connectionString,
                    new SqlServerStorageOptions
                    {
                        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                        QueuePollInterval = TimeSpan.Zero,
                        UseRecommendedIsolationLevel = true,
                        DisableGlobalLocks = true,
                    }));

            // Add the processing server as IHostedService
            builder.Services.AddHangfireServer();

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
            builder.Services.AddScoped<IJwtUtil, JwtUtilSha256>();

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

            builder.Services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(opt =>
                {
                    opt.RequireHttpsMetadata = false;
                    opt.SaveToken = true;
                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = builder.Configuration["Token:Issuer"],
                        ValidAudience = builder.Configuration["Token:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:JwtSecret"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseHangfireDashboard();
            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapHangfireDashboard();

            //app.UseCors(myCorsPolicyName);

            app.UseAuthentication();
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