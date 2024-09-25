using System.ComponentModel.DataAnnotations;

namespace CineApi.Models;

public class CategoriaEntrada {

    [Key]
    public long id { get; set; }

    [Required]
    public string? nombre { get; set; }

    public string? descripcion { get; set; }

    public double precio { get; set; }

    public string? tipo { get; set; }

}