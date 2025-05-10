using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.CMS
{
    public class Strona
    {
        [Key]//to co niżej będzie kluczem podstawowym tabeli
        public int IdStrony { get; set; }

        [Required(ErrorMessage = "Tytuł odnośnika jest wymagany")]//Walidacja, to co niżej jest wymagane
        [MaxLength(10, ErrorMessage = "Link może zawierać max 10 znaków")]//Tak ma nazywać się pole widoczne na widoku
        public required string LinkTytul { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [MaxLength(50, ErrorMessage = "Tytuł może zawierać max 50 znaków")]
        [Display(Name = "Tytuł strony")]
        public required string Tytul { get; set; }

        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]//tu decydujemy jaki jest typ tego pola w bazie danych
        public required string Tresc { get; set; }

        [Display(Name = "Pozycja wyswietlania")]
        [Required(ErrorMessage = "Wpisz pozycje wyswietlania")]
        public int Pozycja { get; set; }
    }
}
