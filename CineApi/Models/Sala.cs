using System.ComponentModel.DataAnnotations;

namespace CineApi.Models;

public class Sala {

    [Key]
    public long id { get; set; }

    [Required]
    public int numero { get; set; }

    public int capacidad { get; set; }

    public string? tipoSala { get; set; }

    public ICollection<Funcion> funciones { get; set; }

    public ICollection<Fila> filas { get; set; }


}