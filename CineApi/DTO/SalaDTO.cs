namespace CineApi.DTO;

public class SalaDTO {

    public long id { get; set; }

    public int numero { get; set; }

    public int capacidad { get; set; }

    public string? tipoSala { get; set; }

    public ICollection<FuncionDTO> funciones { get; set; }

    public ICollection<FilaDTO> filas { get; set; }


}