namespace CineApi.Models;

public class Funcion {
   public long id { get; set; }
   public long peliculaId { get; set; }
   public long salaId { get; set; }
   public DateTime fechaHora { get; set; }
}