using System.ComponentModel.DataAnnotations;

namespace CineApi.Models;

public class Pelicula {

    [Key]
    public long id { get; set; }

    [Required]
    public string? titulo { get; set; }

    public string? descripcion { get; set; }

    public int duracion {get; set; }

    public string? genero { get; set; }

    public string? clasificacion { get; set; }

    public DateOnly fechaEstreno { get; set; }

    public DateOnly fechaFin { get; set; }

    public string? director { get; set; }

    public string? poster { get; set; }

    public ICollection<Boleto> boletosVendidos { get; set; }
    public ICollection<Funcion> funciones { get; set; }

}