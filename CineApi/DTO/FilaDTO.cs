namespace CineApi.DTO;

public class FilaDTO {

    public long id { get; set; }

    public int numero { get; set; }

    public long salaId { get; set; }

    public ICollection<ButacaDTO> butacas { get; set; }

}