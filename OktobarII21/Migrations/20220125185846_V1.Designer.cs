﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace OktobarII21.Migrations
{
    [DbContext(typeof(ProdavnicaContext))]
    [Migration("20220125185846_V1")]
    partial class V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Models.Korpa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Ukupno")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Korpa");
                });

            modelBuilder.Entity("Models.Prodavnica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Prodavnica");
                });

            modelBuilder.Entity("Models.Proizvod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("ProdavnicaID")
                        .HasColumnType("int");

                    b.Property<int?>("TipID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProdavnicaID");

                    b.HasIndex("TipID");

                    b.ToTable("Proizvod");
                });

            modelBuilder.Entity("Models.Spoj", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int?>("KorpaID")
                        .HasColumnType("int");

                    b.Property<int?>("ProizvodID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("KorpaID");

                    b.HasIndex("ProizvodID");

                    b.ToTable("Spoj");
                });

            modelBuilder.Entity("Models.Tip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.ToTable("Tip");
                });

            modelBuilder.Entity("Models.Proizvod", b =>
                {
                    b.HasOne("Models.Prodavnica", "Prodavnica")
                        .WithMany("Proizvodi")
                        .HasForeignKey("ProdavnicaID");

                    b.HasOne("Models.Tip", "Tip")
                        .WithMany("Proizvodi")
                        .HasForeignKey("TipID");

                    b.Navigation("Prodavnica");

                    b.Navigation("Tip");
                });

            modelBuilder.Entity("Models.Spoj", b =>
                {
                    b.HasOne("Models.Korpa", "Korpa")
                        .WithMany("KorpaSpoj")
                        .HasForeignKey("KorpaID");

                    b.HasOne("Models.Proizvod", "Proizvod")
                        .WithMany("ProizvodKorpa")
                        .HasForeignKey("ProizvodID");

                    b.Navigation("Korpa");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("Models.Korpa", b =>
                {
                    b.Navigation("KorpaSpoj");
                });

            modelBuilder.Entity("Models.Prodavnica", b =>
                {
                    b.Navigation("Proizvodi");
                });

            modelBuilder.Entity("Models.Proizvod", b =>
                {
                    b.Navigation("ProizvodKorpa");
                });

            modelBuilder.Entity("Models.Tip", b =>
                {
                    b.Navigation("Proizvodi");
                });
#pragma warning restore 612, 618
        }
    }
}
