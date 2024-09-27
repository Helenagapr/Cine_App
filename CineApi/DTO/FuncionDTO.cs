namespace CineApi.DTO;

public class FuncionDTO {
    public long id { get; set; }

    public DateTime fechaHora { get; set; }

    public long peliculaId { get; set; }

    public long salaId { get; set; }

    public ICollection<BoletoDTO> boletosVendidos { get; set; }


}