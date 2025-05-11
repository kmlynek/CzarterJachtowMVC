using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Data.Flota
{
    public class ZdjecieJachtu
    {
        [Key]
        public int IdZdjecia { get; set; }

        [Required]
        [Display(Name = "Ścieżka do zdjęcia")]
        public string Sciezka { get; set; }

        public int IdJachtu { get; set; }
        public Jacht? Jacht { get; set; }
    }
}