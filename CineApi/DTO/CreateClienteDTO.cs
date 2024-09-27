namespace CineApi.DTO;

public class CreateClienteDTO {

    public string? nombre { get; set; }

    public string? correo { get; set; }

    public string? telefono { get; set; }

    public DateOnly fechaRegistro { get; set; }

}