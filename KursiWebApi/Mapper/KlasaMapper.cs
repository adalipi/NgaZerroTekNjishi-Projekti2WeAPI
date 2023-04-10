using KursiDatabase.Models;
using KursiWebApi.DTOs;

namespace KursiWebApi.Mapper
{
    public static class KlasaMapper
    {
        public static Klasa ToModel(KlasaDto klasaDto)
        {
            return new Klasa 
            {
                 Emri = klasaDto.Emri,
                 Kapaciteti = klasaDto.Kapaciteti
            };
        }
    }
}
