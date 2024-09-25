using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineApi.Models;

public class Fila {

    [Key]
    public long id { get; set; }

    [Required]
    public int numero { get; set; }

    [ForeignKey("salaId")]
    public long salaId { get; set; }
    public Sala sala { get; set; }
    
}