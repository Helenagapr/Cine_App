using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineApi.Models;

public class Boleto {

    [Key]
    public long id { get; set; }

    public DateTime fechaCompra { get; set; }

    [ForeignKey("clienteId")]
    public long clienteId { get; set; }
    public Cliente cliente { get; set; }

    [ForeignKey("peliculaId")]
    public long peliculaId { get; set; }
    public Pelicula pelicula { get; set; }

    [ForeignKey("butacaId")]
    public long butacaId { get; set; }
    public Butaca butaca { get; set; }

    [ForeignKey("categoriaEntradaId")]
    public long categoriaEntradaId { get; set; }
    public CategoriaEntrada categoriaEntrada { get; set; }

}