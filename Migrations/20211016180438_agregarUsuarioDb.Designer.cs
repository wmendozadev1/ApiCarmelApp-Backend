﻿// <auto-generated />
using System;
using APICarmel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APICarmel.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211016180438_agregarUsuarioDb")]
    partial class agregarUsuarioDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APICarmel.Models.GeneralContributions", b =>
                {
                    b.Property<int>("IdContribution")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AnivCordoba")
                        .HasColumnType("float");

                    b.Property<double>("AnivDolar")
                        .HasColumnType("float");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("SeptCordoba")
                        .HasColumnType("float");

                    b.Property<double>("SeptDolar")
                        .HasColumnType("float");

                    b.HasKey("IdContribution");

                    b.ToTable("GeneralContributions");
                });

            modelBuilder.Entity("APICarmel.Models.Members", b =>
                {
                    b.Property<int>("IdMember")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateEntry")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdVacancie")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastDateReEntry")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMember");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("APICarmel.Models.PersonalContributions", b =>
                {
                    b.Property<int>("IdContribution")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdMember")
                        .HasColumnType("int");

                    b.Property<double>("ProCasaCordoba")
                        .HasColumnType("float");

                    b.Property<double>("ProCasaDolar")
                        .HasColumnType("float");

                    b.Property<double>("ProMejoraCordoba")
                        .HasColumnType("float");

                    b.Property<double>("ProMejoraDolar")
                        .HasColumnType("float");

                    b.Property<double>("ProRentaCordoba")
                        .HasColumnType("float");

                    b.Property<double>("ProRentaDolar")
                        .HasColumnType("float");

                    b.HasKey("IdContribution");

                    b.ToTable("PersonalContributions");
                });

            modelBuilder.Entity("APICarmel.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("APICarmel.Models.Vacancies", b =>
                {
                    b.Property<int>("IdVacancie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdVacancie");

                    b.ToTable("Vacancies");
                });
#pragma warning restore 612, 618
        }
    }
}