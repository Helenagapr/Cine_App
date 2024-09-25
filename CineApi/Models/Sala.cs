namespace CineApi.Models;

public class Sala {
   public long id { get; set; }
   public int numero { get; set; }
   public int capacidad { get; set; }
   public string? tipoSala { get; set; }
}