using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursiDatabase.Models
{
    public class Klasa : BaseModel
    {
        [Required]
        public string Emri { get; set; }

        [Required]
        public int Kapaciteti { get; set; }
    }
}
