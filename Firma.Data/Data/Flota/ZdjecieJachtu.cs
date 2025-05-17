using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Firma.Data.Data.Flota;
using Microsoft.AspNetCore.Http;

namespace Firma.Data.Data.Flota
{
    public class ZdjecieJachtu
    {
        [Key]
        public int IdZdjecia { get; set; }

        [Required]
        [Display(Name = "Ścieżka do zdjęcia (np.jacht1.jpg)")]
        public string Sciezka { get; set; }

        [Display(Name = "Jacht")]
        public int IdJachtu { get; set; }
        public Jacht? Jacht { get; set; }
    }

}