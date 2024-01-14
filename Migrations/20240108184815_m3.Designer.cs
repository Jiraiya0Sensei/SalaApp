﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalaApp.Data;

#nullable disable

namespace SalaApp.Migrations
{
    [DbContext(typeof(SalaAppContext))]
    [Migration("20240108184815_m3")]
    partial class m3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AbonamentClient", b =>
                {
                    b.Property<int>("AbonamenteID")
                        .HasColumnType("int");

                    b.Property<int>("ClientiID")
                        .HasColumnType("int");

                    b.HasKey("AbonamenteID", "ClientiID");

                    b.HasIndex("ClientiID");

                    b.ToTable("AbonamentClient");
                });

            modelBuilder.Entity("SalaApp.Models.Abonament", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("Data_expirare")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Data_inceput")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("ID");

                    b.ToTable("Abonament");
                });

            modelBuilder.Entity("SalaApp.Models.Antrenor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SportID")
                        .HasColumnType("int");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("SportID");

                    b.ToTable("Antrenor");
                });

            modelBuilder.Entity("SalaApp.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AbonamentID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("SalaApp.Models.Programare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("AntrenorID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("ClientID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ora_inceput")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ora_sfarsit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AntrenorID");

                    b.HasIndex("ClientID");

                    b.ToTable("Programare");
                });

            modelBuilder.Entity("SalaApp.Models.Sport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Denumire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Sport");
                });

            modelBuilder.Entity("AbonamentClient", b =>
                {
                    b.HasOne("SalaApp.Models.Abonament", null)
                        .WithMany()
                        .HasForeignKey("AbonamenteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalaApp.Models.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SalaApp.Models.Antrenor", b =>
                {
                    b.HasOne("SalaApp.Models.Sport", "Sport")
                        .WithMany()
                        .HasForeignKey("SportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sport");
                });

            modelBuilder.Entity("SalaApp.Models.Programare", b =>
                {
                    b.HasOne("SalaApp.Models.Antrenor", "Antrenor")
                        .WithMany("Programari")
                        .HasForeignKey("AntrenorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalaApp.Models.Client", "Client")
                        .WithMany("Programari")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Antrenor");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("SalaApp.Models.Antrenor", b =>
                {
                    b.Navigation("Programari");
                });

            modelBuilder.Entity("SalaApp.Models.Client", b =>
                {
                    b.Navigation("Programari");
                });
#pragma warning restore 612, 618
        }
    }
}