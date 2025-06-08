using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.CMS
{
    public class Parametr
    {
        [Key]
        public int IdParametru { get; set; }

        [Required]
        public string Klucz { get; set; }

        public string Wartosc { get; set; }
    }
}
