using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineApi.Models;

public class Funcion {

    [Key]
    public long id { get; set; }

    [Required]
    public DateTime fechaHora { get; set; }

    [ForeignKey("peliculaId")]
    public long peliculaId { get; set; }
    public Pelicula pelicula { get; set; }

    [ForeignKey("salaId")]
    public long salaId { get; set; }
    public Sala sala { get; set; }

    public ICollection<Boleto> boletosVendidos { get; set; }


}