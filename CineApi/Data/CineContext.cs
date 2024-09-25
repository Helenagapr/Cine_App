using Microsoft.EntityFrameworkCore;
using CineApi.Models;
using System.Xml;

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


}