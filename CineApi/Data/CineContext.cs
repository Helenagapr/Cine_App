using Microsoft.EntityFrameworkCore;
using CineApi.Models;
using System.Xml;
using System.IO.Compression;

namespace CineApi.Data;

public class CineContext : DbContext
{
    public CineContext(DbContextOptions<CineContext> options)
        : base(options)
    {
    }

    public DbSet<Boleto> Boletos { get; set; }
    public DbSet<Butaca> Butacas { get; set; }
    public DbSet<CategoriaEntrada> CategoriaEntradas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Fila> Filas { get; set; }
    public DbSet<Funcion> Funciones { get; set; }
    public DbSet<Pelicula> Peliculas { get; set; }
    public DbSet<Sala> Salas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Boleto>()
        .HasOne(c => c.cliente)
        .WithMany(b => b.historialCompras)
        .HasForeignKey(c => c.clienteId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Boleto>()
        .HasOne(p => p.pelicula)
        .WithMany(b => b.boletosVendidos)
        .HasForeignKey(p => p.peliculaId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Boleto>()
        .HasOne(a => a.butaca)
        .WithMany()
        .HasForeignKey(a => a.butacaId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Boleto>()
        .HasOne(c => c.categoriaEntrada)
        .WithMany()
        .HasForeignKey(c => c.categoriaEntradaId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Butaca>()
        .HasOne(f => f.fila)
        .WithMany(b => b.butacas)
        .HasForeignKey(f => f.filaId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Fila>()
        .HasOne(s => s.sala)
        .WithMany(f => f.filas)
        .HasForeignKey(s => s.salaId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Funcion>()
        .HasOne(p => p.pelicula)
        .WithMany(f => f.funciones)
        .HasForeignKey(p => p.peliculaId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Funcion>()
        .HasOne(s => s.sala)
        .WithMany(f => f.funciones)
        .HasForeignKey(s => s.salaId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Sala>()
        .HasIndex(n => n.numero)
        .IsUnique();

        modelBuilder.Entity<Cliente>()
        .HasIndex(c => c.correo)
        .IsUnique();

        base.OnModelCreating(modelBuilder);
    }


}