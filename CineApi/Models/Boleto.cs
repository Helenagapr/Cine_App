using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CineApi.Models;

public class Boleto {
    [Key]
    public long id { get; set; }

    public DateTime fechaCompra { get; set; }

    [ForeignKey("clienteId")]
    public int clienteId { get; set; }
    public Cliente cliente { get; set; }

    
    public long peliculaId { get; set; }
    public bool asientoId { get; set; }
    public string? tipoEntradaId { get; set; }

}