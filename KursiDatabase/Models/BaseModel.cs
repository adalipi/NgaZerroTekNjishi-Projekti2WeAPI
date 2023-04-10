using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursiDatabase.Models
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            this.DataKrijimit = DateTime.Now;
            this.DataNdryshimit = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime DataKrijimit { get; set; }

        [Required]
        public DateTime DataNdryshimit { get; set; }
    }
}
