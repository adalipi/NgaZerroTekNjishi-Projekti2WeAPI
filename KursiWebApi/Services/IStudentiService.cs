using KursiDatabase.Models;
using KursiWebApi.DTOs;

namespace KursiWebApi.Services
{
    public interface IStudentiService
    {
        Task<Studenti?> GjejStudentinPermesEmailit(string email, CancellationToken token);
        Task RegjistroStudentin(StudentiDto studenti, CancellationToken token);

        Task<IEnumerable<StudentiDto>> GjitheStudentet(CancellationToken token);
    }
}
