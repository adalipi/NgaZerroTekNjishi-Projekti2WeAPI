using KursiDatabase.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KursiWebApi.DTOs
{
    public class LendaDto
    {
        public string Emri { get; set; }

        public string Klasa { get; set; }

        //public IEnumerable<string> Studentet { get; set; }
    }
}
