namespace CineApi.Models;

public class Butaca {
   public long id { get; set; }
   public int numero { get; set; }
   public long filaId { get; set; }
   public bool disponible { get; set; }
   public string? categoria { get; set; }
}