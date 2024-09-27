namespace CineApi.DTO;

public class ClienteDTO {

    public long id { get; set; }

    public string? nombre { get; set; }

    public string? correo { get; set; }

    public string? telefono { get; set; }

    public DateOnly fechaRegistro { get; set; }

    public ICollection<BoletoDTO> historialCompras { get; set; }
}