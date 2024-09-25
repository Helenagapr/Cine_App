using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineApi.Models;

public class Butaca {

    [Key]
    public long id { get; set; }
    
    [Required]
    public int numero { get; set; }

    public bool disponible { get; set; }
    
    public string? categoria { get; set; }

    [ForeignKey("filaId")]
    public long filaId { get; set; }
    public Fila fila { get; set; }

}