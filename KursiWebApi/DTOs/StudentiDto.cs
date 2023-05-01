using System.ComponentModel.DataAnnotations;

namespace KursiWebApi.DTOs
{
    public class StudentiDto
    {
        public string Emri { get; set; }
        public int Mosha { get; set; }
        public string Email { get; set; }
        public string Fjalkalimi { get; set; }
    }
}
