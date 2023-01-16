﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using parafia2.Models.DataLayer;

#nullable disable

namespace parafia2.Migrations
{
    [DbContext(typeof(ParafiaContext))]
    [Migration("20230116073524_cos")]
    partial class cos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("parafia2.Models.DataLayer.Ksieza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Imie")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nazwisko")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("Stanowisko")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Stanowisko");

                    b.ToTable("Ksieza");
                });

            modelBuilder.Entity("parafia2.Models.DataLayer.Ministranci", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataUrodzenia")
                        .HasColumnType("date")
                        .HasColumnName("Data_urodzenia");

                    b.Property<string>("Imie")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nazwisko")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Ministranci");
                });

            modelBuilder.Entity("parafia2.Models.DataLayer.Msze", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataMszy")
                        .HasColumnType("date")
                        .HasColumnName("Data_mszy");

                    b.Property<int?>("Ksiadz")
                        .HasColumnType("int")
                        .HasColumnName("ksiadz");

                    b.Property<int?>("Ministrant")
                        .HasColumnType("int")
                        .HasColumnName("ministrant");

                    b.HasKey("Id");

                    b.HasIndex("Ksiadz");

                    b.HasIndex("Ministrant");

                    b.ToTable("Msze");
                });

            modelBuilder.Entity("parafia2.Models.DataLayer.Stanowiska", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NazwaStanowiska")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nazwa_stanowiska");

                    b.HasKey("Id");

                    b.ToTable("Stanowiska");
                });

            modelBuilder.Entity("parafia2.Models.DataLayer.Ksieza", b =>
                {
                    b.HasOne("parafia2.Models.DataLayer.Stanowiska", "StanowiskoNavigation")
                        .WithMany("Ksiezas")
                        .HasForeignKey("Stanowisko")
                        .HasConstraintName("FK_Ksieza_Stanowiska");

                    b.Navigation("StanowiskoNavigation");
                });

            modelBuilder.Entity("parafia2.Models.DataLayer.Msze", b =>
                {
                    b.HasOne("parafia2.Models.DataLayer.Ksieza", "KsiadzNavigation")
                        .WithMany("Mszes")
                        .HasForeignKey("Ksiadz")
                        .HasConstraintName("FK_Msze_Ksieza");

                    b.HasOne("parafia2.Models.DataLayer.Ministranci", "MinistrantNavigation")
                        .WithMany("Mszes")
                        .HasForeignKey("Ministrant")
                        .HasConstraintName("FK_Msze_Ministranci");

                    b.Navigation("KsiadzNavigation");

                    b.Navigation("MinistrantNavigation");
                });

            modelBuilder.Entity("parafia2.Models.DataLayer.Ksieza", b =>
                {
                    b.Navigation("Mszes");
                });

            modelBuilder.Entity("parafia2.Models.DataLayer.Ministranci", b =>
                {
                    b.Navigation("Mszes");
                });

            modelBuilder.Entity("parafia2.Models.DataLayer.Stanowiska", b =>
                {
                    b.Navigation("Ksiezas");
                });
#pragma warning restore 612, 618
        }
    }
}
