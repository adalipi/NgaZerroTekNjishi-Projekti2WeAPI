﻿using System;
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
        [ForeignKey("KlasaIdi")]//ky eshte emri i kolones per id te klases tek tabela Lendet
        public Klasa Klasa { get; set; }

        [ForeignKey("IdELendes")]//id e lendes qe eshte si foreign key ne tabelen e lidhjes
        public virtual ICollection<Studenti> Studentet { get; set; }
    }
}
