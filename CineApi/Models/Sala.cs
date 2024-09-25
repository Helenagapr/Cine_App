using System.ComponentModel.DataAnnotations;

namespace CineApi.Models;

public class Sala {

    [Key]
    public long id { get; set; }

    [Required]
    public int numero { get; set; }

    public int capacidad { get; set; }

    public string? tipoSala { get; set; }
    
}