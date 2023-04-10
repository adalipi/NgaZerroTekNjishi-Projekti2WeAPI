using KursiWebApi.DTOs;

namespace KursiWebApi.Services
{
    public interface ILendetService
    {
        Task RegjistroLenden(LendaDto lendaDto, CancellationToken token);
    }
}
