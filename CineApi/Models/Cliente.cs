namespace CineApi.Models;

public class Cliente {
   public long id { get; set; }
   public string? nombre { get; set; }
   public string? correo { get; set; }
   public string? telefono { get; set; }
   public DateOnly fechaRegistro { get; set; }
}