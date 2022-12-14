// <auto-generated />
using System;
using CoWin.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoWin.Infrastructure.Migrations
{
    [DbContext(typeof(VaccinationContext))]
    [Migration("20220814083725_InitialCreateDb")]
    partial class InitialCreateDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoWin.Domain.Entities.VaccinationDates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("FirstDose")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SecondDose")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("VaccinationDates");
                });

            modelBuilder.Entity("CoWin.Domain.Entities.VaccinationDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DateOfVaccinationId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VaccinationId")
                        .HasColumnType("int");

                    b.Property<int?>("VaccinationPlaceId")
                        .HasColumnType("int");

                    b.Property<string>("VaccineName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DateOfVaccinationId");

                    b.HasIndex("VaccinationPlaceId");

                    b.ToTable("VaccinationDetails");
                });

            modelBuilder.Entity("CoWin.Domain.Entities.VaccinationPlaces", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstDose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondDose")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VaccinationPlaces");
                });

            modelBuilder.Entity("CoWin.Domain.Entities.VaccinationDetail", b =>
                {
                    b.HasOne("CoWin.Domain.Entities.VaccinationDates", "DateOfVaccination")
                        .WithMany()
                        .HasForeignKey("DateOfVaccinationId");

                    b.HasOne("CoWin.Domain.Entities.VaccinationPlaces", "VaccinationPlace")
                        .WithMany()
                        .HasForeignKey("VaccinationPlaceId");

                    b.Navigation("DateOfVaccination");

                    b.Navigation("VaccinationPlace");
                });
#pragma warning restore 612, 618
        }
    }
}
