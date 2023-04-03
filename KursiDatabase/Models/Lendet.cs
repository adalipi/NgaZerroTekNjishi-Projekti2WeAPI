using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursiDatabase.Models
{
    public class Lendet : BaseModel
    {
        [Required]
        public string Emri { get; set; }

        [Required]
        public string Klasa { get; set; }
    }
}
