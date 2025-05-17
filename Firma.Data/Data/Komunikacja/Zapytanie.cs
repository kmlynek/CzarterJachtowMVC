using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Data.Komunikacja
{
    public class Zapytanie
    {
        [Key]
        public int IdZapytania { get; set; }

        [Required]
        [Display(Name = "Temat zapytania")]
        public string Temat { get; set; }

        [Display(Name = "Treść wiadomości")]
        public string? Tresc { get; set; }

        [Required, EmailAddress]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set; }

        [Display(Name = "Data wysłania")]
        public DateTime DataWyslania { get; set; }

    }
}
