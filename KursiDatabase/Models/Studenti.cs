using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KursiDatabase.Models
{
    public class Studenti : BaseModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Fjalkalimi { get; set; }

        [Required]
        public string Emri { get; set; }

        [Required]
        public int Mosha { get; set; }

        [ForeignKey("IdEStudentit")]//id e studentit qe eshte si foreign key ne tabelen e lidhjes
        public virtual ICollection<Lendet> LendetEStudentit { get; set; }
    }
}
