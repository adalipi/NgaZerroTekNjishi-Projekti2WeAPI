using KursiDatabase.Models;
using KursiWebApi.DTOs;

namespace KursiWebApi.Mapper
{
    public static class StudentiMapper
    {
        public static Studenti ToModel(StudentiDto studentiDto)
        {
            return new Studenti
            {
                Emri = studentiDto.Emri,
                Email = studentiDto.Email, 
                Mosha = studentiDto.Mosha,
                Fjalkalimi = studentiDto.Fjalkalimi
            };
        }

        public static StudentiDto ToDTO(this Studenti studenti) => new()
        {
            Emri= studenti.Emri, 
            Mosha=studenti.Mosha,
            Email= studenti.Email, 
            Fjalkalimi =studenti.Fjalkalimi
        };

        public static IEnumerable<StudentiDto> ToDTOs(this IEnumerable<Studenti> studentet) =>
            studentet.Select(s => ToDTO(s));
    }
}
