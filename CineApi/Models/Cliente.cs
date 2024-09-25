using System.ComponentModel.DataAnnotations;

namespace CineApi.Models;

public class Cliente {

    [Key]
    public long id { get; set; }

    [Required]
    public string? nombre { get; set; }

    public string? correo { get; set; }

    public string? telefono { get; set; }

    public DateOnly fechaRegistro { get; set; }

    public ICollection<Boleto> historialCompras { get; set; }
}