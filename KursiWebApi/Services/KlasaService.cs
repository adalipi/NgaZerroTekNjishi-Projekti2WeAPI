using KursiDatabase.Models;
using KursiDatabase.Repository;
using KursiWebApi.DTOs;
using KursiWebApi.Mapper;

namespace KursiWebApi.Services
{
    public class KlasaService : IKlasaService
    {
        private readonly IRepository<Klasa> _repository;

        public KlasaService(IRepository<Klasa> repository)
        {
            _repository = repository;
        }

        public async Task RegisterKlasa(KlasaDto klasaDto, CancellationToken token)
        {
            var model = KlasaMapper.ToModel(klasaDto);
            _repository.Add(model);
            await _repository.SaveAsync(token);
        }


    }
}
