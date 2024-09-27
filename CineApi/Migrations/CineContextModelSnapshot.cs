﻿// <auto-generated />
using System;
using CineApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CineApi.Migrations
{
    [DbContext(typeof(CineContext))]
    partial class CineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CineApi.Models.Boleto", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<long?>("Funcionid")
                        .HasColumnType("bigint");

                    b.Property<long>("butacaId")
                        .HasColumnType("bigint");

                    b.Property<long>("categoriaEntradaId")
                        .HasColumnType("bigint");

                    b.Property<long>("clienteId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("fechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<long>("peliculaId")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("Funcionid");

                    b.HasIndex("butacaId");

                    b.HasIndex("categoriaEntradaId");

                    b.HasIndex("clienteId");

                    b.HasIndex("peliculaId");

                    b.ToTable("Boletos");
                });

            modelBuilder.Entity("CineApi.Models.Butaca", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("disponible")
                        .HasColumnType("bit");

                    b.Property<long>("filaId")
                        .HasColumnType("bigint");

                    b.Property<int>("numero")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("filaId");

                    b.ToTable("Butacas");
                });

            modelBuilder.Entity("CineApi.Models.CategoriaEntrada", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("precio")
                        .HasColumnType("float");

                    b.Property<string>("tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("CategoriaEntradas");
                });

            modelBuilder.Entity("CineApi.Models.Cliente", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("correo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateOnly>("fechaRegistro")
                        .HasColumnType("date");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("correo")
                        .IsUnique()
                        .HasFilter("[correo] IS NOT NULL");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("CineApi.Models.Fila", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<int>("numero")
                        .HasColumnType("int");

                    b.Property<long>("salaId")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("salaId");

                    b.ToTable("Filas");
                });

            modelBuilder.Entity("CineApi.Models.Funcion", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<DateTime>("fechaHora")
                        .HasColumnType("datetime2");

                    b.Property<long>("peliculaId")
                        .HasColumnType("bigint");

                    b.Property<long>("salaId")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("peliculaId");

                    b.HasIndex("salaId");

                    b.ToTable("Funciones");
                });

            modelBuilder.Entity("CineApi.Models.Pelicula", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<string>("clasificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("director")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("duracion")
                        .HasColumnType("int");

                    b.Property<DateOnly>("fechaEstreno")
                        .HasColumnType("date");

                    b.Property<DateOnly>("fechaFin")
                        .HasColumnType("date");

                    b.Property<string>("genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("poster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Peliculas");
                });

            modelBuilder.Entity("CineApi.Models.Sala", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"));

                    b.Property<int>("capacidad")
                        .HasColumnType("int");

                    b.Property<int>("numero")
                        .HasColumnType("int");

                    b.Property<string>("tipoSala")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("numero")
                        .IsUnique();

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("CineApi.Models.Boleto", b =>
                {
                    b.HasOne("CineApi.Models.Funcion", null)
                        .WithMany("boletosVendidos")
                        .HasForeignKey("Funcionid");

                    b.HasOne("CineApi.Models.Butaca", "butaca")
                        .WithMany()
                        .HasForeignKey("butacaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CineApi.Models.CategoriaEntrada", "categoriaEntrada")
                        .WithMany()
                        .HasForeignKey("categoriaEntradaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CineApi.Models.Cliente", "cliente")
                        .WithMany("historialCompras")
                        .HasForeignKey("clienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CineApi.Models.Pelicula", "pelicula")
                        .WithMany("boletosVendidos")
                        .HasForeignKey("peliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("butaca");

                    b.Navigation("categoriaEntrada");

                    b.Navigation("cliente");

                    b.Navigation("pelicula");
                });

            modelBuilder.Entity("CineApi.Models.Butaca", b =>
                {
                    b.HasOne("CineApi.Models.Fila", "fila")
                        .WithMany("butacas")
                        .HasForeignKey("filaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("fila");
                });

            modelBuilder.Entity("CineApi.Models.Fila", b =>
                {
                    b.HasOne("CineApi.Models.Sala", "sala")
                        .WithMany("filas")
                        .HasForeignKey("salaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("sala");
                });

            modelBuilder.Entity("CineApi.Models.Funcion", b =>
                {
                    b.HasOne("CineApi.Models.Pelicula", "pelicula")
                        .WithMany("funciones")
                        .HasForeignKey("peliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CineApi.Models.Sala", "sala")
                        .WithMany("funciones")
                        .HasForeignKey("salaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("pelicula");

                    b.Navigation("sala");
                });

            modelBuilder.Entity("CineApi.Models.Cliente", b =>
                {
                    b.Navigation("historialCompras");
                });

            modelBuilder.Entity("CineApi.Models.Fila", b =>
                {
                    b.Navigation("butacas");
                });

            modelBuilder.Entity("CineApi.Models.Funcion", b =>
                {
                    b.Navigation("boletosVendidos");
                });

            modelBuilder.Entity("CineApi.Models.Pelicula", b =>
                {
                    b.Navigation("boletosVendidos");

                    b.Navigation("funciones");
                });

            modelBuilder.Entity("CineApi.Models.Sala", b =>
                {
                    b.Navigation("filas");

                    b.Navigation("funciones");
                });
#pragma warning restore 612, 618
        }
    }
}
