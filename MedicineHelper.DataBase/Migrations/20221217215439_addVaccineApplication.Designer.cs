// <auto-generated />
using System;
using MedicineHelper.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedicineHelper.DataBase.Migrations
{
    [DbContext(typeof(MedicineHelperContext))]
    [Migration("20221217215439_addVaccineApplication")]
    partial class addVaccineApplication
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DescriptionOfDestination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DiseaseHistoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DiseaseHistoryId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Clinic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperatingMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceClinicUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Conclusion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClinicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfAnalysis")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameOfConclusion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ScanOfAnalysisDocument")
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ClinicId");

                    b.HasIndex("UserId");

                    b.ToTable("Conclusions");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Disease", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.DiseaseHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("BoolTypeOfTreatment")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateOfDisease")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfRecovery")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DiseaseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SeverityOfTheIllness")
                        .HasColumnType("int");

                    b.Property<string>("TypeOfTreatment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DiseaseId");

                    b.HasIndex("UserId");

                    b.ToTable("DiseaseHistores");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Rating")
                        .HasColumnType("real");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.DoctorVisit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClinicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ConclusionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateVisit")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DiseaseHistoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("PriceVisit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("ConclusionId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("UserId");

                    b.ToTable("DoctorVisits");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Fluorography", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClinicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataOfFluorography")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDateOfFluorography")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumberFluorography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Result")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("UserId");

                    b.ToTable("Fluorographies");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Medicine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Instructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOfMedicine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.MedicinePrescription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClinicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndOfAdmission")
                        .HasColumnType("datetime2");

                    b.Property<string>("MedicineDose")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MedicineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("MedicinePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartOfAdmission")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ClinicId");

                    b.HasIndex("MedicineId");

                    b.HasIndex("UserId");

                    b.ToTable("MedicinePrescriptions");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.MedicineProcedure", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClinicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndProcedure")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameOfProcedure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartProcedure")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ClinicId");

                    b.HasIndex("UserId");

                    b.ToTable("MedicineProcedures");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.MedicineСheckup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AppointmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClinicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfMedicineСheckup")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PriceOfMedicineСheckup")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ClinicId");

                    b.HasIndex("UserId");

                    b.ToTable("MedicineСheckups");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Token")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Avatar")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FulFirst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Vaccination", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApplicationOfVaccine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ClinicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfVaccination")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameOfVaccine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("VaccinationExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VaccineProducingCountry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VacineSeria")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("UserId");

                    b.ToTable("Vaccinations");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Appointment", b =>
                {
                    b.HasOne("MedicineHelper.DataBase.Entities.DiseaseHistory", "DiseaseHistory")
                        .WithMany("Appointments")
                        .HasForeignKey("DiseaseHistoryId");

                    b.HasOne("MedicineHelper.DataBase.Entities.DoctorVisit", "DoctorVisit")
                        .WithOne("Appointment")
                        .HasForeignKey("MedicineHelper.DataBase.Entities.Appointment", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiseaseHistory");

                    b.Navigation("DoctorVisit");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Conclusion", b =>
                {
                    b.HasOne("MedicineHelper.DataBase.Entities.Appointment", "Appointment")
                        .WithMany("Conclusion")
                        .HasForeignKey("AppointmentId");

                    b.HasOne("MedicineHelper.DataBase.Entities.Clinic", "Clinic")
                        .WithMany("Conclusion")
                        .HasForeignKey("ClinicId");

                    b.HasOne("MedicineHelper.DataBase.Entities.User", "User")
                        .WithMany("Conclusion")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Clinic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.DiseaseHistory", b =>
                {
                    b.HasOne("MedicineHelper.DataBase.Entities.Disease", "Disease")
                        .WithMany("DiseaseHistory")
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicineHelper.DataBase.Entities.User", "User")
                        .WithMany("DiseaseHistory")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disease");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.DoctorVisit", b =>
                {
                    b.HasOne("MedicineHelper.DataBase.Entities.Clinic", "Clinic")
                        .WithMany("DoctorVisits")
                        .HasForeignKey("ClinicId");

                    b.HasOne("MedicineHelper.DataBase.Entities.Conclusion", null)
                        .WithMany("DoctorVisit")
                        .HasForeignKey("ConclusionId");

                    b.HasOne("MedicineHelper.DataBase.Entities.Doctor", "Doctor")
                        .WithMany("DoctorVisits")
                        .HasForeignKey("DoctorId");

                    b.HasOne("MedicineHelper.DataBase.Entities.User", "User")
                        .WithMany("DoctorVisits")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinic");

                    b.Navigation("Doctor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Fluorography", b =>
                {
                    b.HasOne("MedicineHelper.DataBase.Entities.Clinic", "Clinic")
                        .WithMany("Fluorographys")
                        .HasForeignKey("ClinicId");

                    b.HasOne("MedicineHelper.DataBase.Entities.User", "User")
                        .WithMany("Fluorographies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.MedicinePrescription", b =>
                {
                    b.HasOne("MedicineHelper.DataBase.Entities.Appointment", null)
                        .WithMany("MedicinePrescription")
                        .HasForeignKey("AppointmentId");

                    b.HasOne("MedicineHelper.DataBase.Entities.Clinic", null)
                        .WithMany("MedicinePrescription")
                        .HasForeignKey("ClinicId");

                    b.HasOne("MedicineHelper.DataBase.Entities.Medicine", "Medicine")
                        .WithMany("MedicinePrescription")
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicineHelper.DataBase.Entities.User", "User")
                        .WithMany("MedicinePrescription")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicine");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.MedicineProcedure", b =>
                {
                    b.HasOne("MedicineHelper.DataBase.Entities.Appointment", "Appointment")
                        .WithMany("MedicineProcedure")
                        .HasForeignKey("AppointmentId");

                    b.HasOne("MedicineHelper.DataBase.Entities.Clinic", "Clinic")
                        .WithMany("MedicineProcedure")
                        .HasForeignKey("ClinicId");

                    b.HasOne("MedicineHelper.DataBase.Entities.User", "User")
                        .WithMany("MedicineProcedure")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Clinic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.MedicineСheckup", b =>
                {
                    b.HasOne("MedicineHelper.DataBase.Entities.Appointment", "Appointment")
                        .WithMany("MedicineСheckup")
                        .HasForeignKey("AppointmentId");

                    b.HasOne("MedicineHelper.DataBase.Entities.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId");

                    b.HasOne("MedicineHelper.DataBase.Entities.User", "User")
                        .WithMany("MedicineСheckup")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Clinic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.RefreshToken", b =>
                {
                    b.HasOne("MedicineHelper.DataBase.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.User", b =>
                {
                    b.HasOne("MedicineHelper.DataBase.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Vaccination", b =>
                {
                    b.HasOne("MedicineHelper.DataBase.Entities.Clinic", "Clinic")
                        .WithMany("Vaccinations")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicineHelper.DataBase.Entities.User", "User")
                        .WithMany("Vaccinations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Appointment", b =>
                {
                    b.Navigation("Conclusion");

                    b.Navigation("MedicinePrescription");

                    b.Navigation("MedicineProcedure");

                    b.Navigation("MedicineСheckup");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Clinic", b =>
                {
                    b.Navigation("Conclusion");

                    b.Navigation("DoctorVisits");

                    b.Navigation("Fluorographys");

                    b.Navigation("MedicinePrescription");

                    b.Navigation("MedicineProcedure");

                    b.Navigation("Vaccinations");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Conclusion", b =>
                {
                    b.Navigation("DoctorVisit");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Disease", b =>
                {
                    b.Navigation("DiseaseHistory");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.DiseaseHistory", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Doctor", b =>
                {
                    b.Navigation("DoctorVisits");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.DoctorVisit", b =>
                {
                    b.Navigation("Appointment")
                        .IsRequired();
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Medicine", b =>
                {
                    b.Navigation("MedicinePrescription");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.User", b =>
                {
                    b.Navigation("Conclusion");

                    b.Navigation("DiseaseHistory");

                    b.Navigation("DoctorVisits");

                    b.Navigation("Fluorographies");

                    b.Navigation("MedicinePrescription");

                    b.Navigation("MedicineProcedure");

                    b.Navigation("MedicineСheckup");

                    b.Navigation("RefreshTokens");

                    b.Navigation("Vaccinations");
                });
#pragma warning restore 612, 618
        }
    }
}
