namespace CineApi.DTO;

public class BoletoDTO {

    public long id { get; set; }

    public DateTime fechaCompra { get; set; }

    public long clienteId { get; set; }

    public long peliculaId { get; set; }

    public long butacaId { get; set; }

    public long categoriaEntradaId { get; set; }
 
}