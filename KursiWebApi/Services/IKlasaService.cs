using KursiWebApi.DTOs;

namespace KursiWebApi.Services
{
    public interface IKlasaService
    {
        Task RegisterKlasa(KlasaDto klasa, CancellationToken token);
    }
}
