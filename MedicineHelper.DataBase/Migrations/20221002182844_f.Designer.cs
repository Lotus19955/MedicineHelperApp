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
    [Migration("20221002182844_f")]
    partial class f
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DoctorsVisits", b =>
                {
                    b.Property<Guid>("VisitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VisitedDoctorsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VisitId", "VisitedDoctorsId");

                    b.HasIndex("VisitedDoctorsId");

                    b.ToTable("DoctorsVisits");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Currencies", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Doctors", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("VaccinationsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VisitsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VaccinationsId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.DoctorsSpecializations", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("DoctorsSpecializations");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Medicines", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("CurrencieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Currescies")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MedicinesPrescriptonsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CurrencieId");

                    b.HasIndex("MedicinesPrescriptonsId");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.MedicinesPrescriptons", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfPrescriptionEnd")
                        .HasColumnType("datetime2");

                    b.Property<int>("DaysOfMedication")
                        .HasColumnType("int");

                    b.Property<int>("MedicineDose")
                        .HasColumnType("int");

                    b.Property<Guid>("MedicinesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumberOfMedicinePerDay")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("VisitsConclusionsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("MedicinesPrescriptons");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirgth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("VisitsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VisitsId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Vaccinations", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfVaccination")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DoctorsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VaccinesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Vaccinations");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Vaccines", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("CurrenciesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfEndVaccine")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("VaccinationsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CurrenciesId");

                    b.HasIndex("VaccinationsId");

                    b.ToTable("Vaccines");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Visits", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("CurrenciesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DoctorsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("VisitsConclusionsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CurrenciesId");

                    b.HasIndex("VisitsConclusionsId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.VisitsConclusions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MedicinesPrescriptonsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VisitsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MedicinesPrescriptonsId");

                    b.ToTable("VisitsConclusions");
                });

            modelBuilder.Entity("DoctorsVisits", b =>
                {
                    b.HasOne("MedicineHelper.DataBase.Entities.Visits", null)
                        .WithMany()
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicineHelper.DataBase.Entities.Doctors", null)
                        .WithMany()
                        .HasForeignKey("VisitedDoctorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Doctors", b =>
                {
                    b.HasOne("MedicineHelper.DataBase.Entities.Vaccinations", null)
                        .WithMany("Doctor")
                        .HasForeignKey("VaccinationsId");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Medicines", b =>
                {
                    b.HasOne("MedicineHelper.DataBase.Entities.Currencies", "Currencie")
                        .WithMany()
                        .HasForeignKey("CurrencieId");

                    b.HasOne("MedicineHelper.DataBase.Entities.MedicinesPrescriptons", null)
                        .WithMany("Medicine")
                        .HasForeignKey("MedicinesPrescriptonsId");

                    b.Navigation("Currencie");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Users", b =>
                {
                    b.HasOne("MedicineHelper.DataBase.Entities.Visits", null)
                        .WithMany("Users")
                        .HasForeignKey("VisitsId");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Vaccinations", b =>
                {
                    b.HasOne("MedicineHelper.DataBase.Entities.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Vaccines", b =>
                {
                    b.HasOne("MedicineHelper.DataBase.Entities.Currencies", "Currensies")
                        .WithMany()
                        .HasForeignKey("CurrenciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicineHelper.DataBase.Entities.Vaccinations", null)
                        .WithMany("Vaccine")
                        .HasForeignKey("VaccinationsId");

                    b.Navigation("Currensies");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Visits", b =>
                {
                    b.HasOne("MedicineHelper.DataBase.Entities.Currencies", "Currensies")
                        .WithMany()
                        .HasForeignKey("CurrenciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicineHelper.DataBase.Entities.VisitsConclusions", null)
                        .WithMany("Visit")
                        .HasForeignKey("VisitsConclusionsId");

                    b.Navigation("Currensies");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.VisitsConclusions", b =>
                {
                    b.HasOne("MedicineHelper.DataBase.Entities.MedicinesPrescriptons", "Prescription")
                        .WithMany("VisitsConclusion")
                        .HasForeignKey("MedicinesPrescriptonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.MedicinesPrescriptons", b =>
                {
                    b.Navigation("Medicine");

                    b.Navigation("VisitsConclusion");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Vaccinations", b =>
                {
                    b.Navigation("Doctor");

                    b.Navigation("Vaccine");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.Visits", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MedicineHelper.DataBase.Entities.VisitsConclusions", b =>
                {
                    b.Navigation("Visit");
                });
#pragma warning restore 612, 618
        }
    }
}
