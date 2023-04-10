using KursiDatabase.Models;
using KursiDatabase.Repository;
using KursiWebApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace KursiWebApi.Services
{
    public class LendetService : ILendetService
    {
        private readonly IRepository<Lendet> _lendetRepository;
        private readonly IRepository<Klasa> _klasaRepositry;

        public LendetService(IRepository<Lendet> repositoryLenda, IRepository<Klasa> klasaRepositry)
        {
            _lendetRepository = repositoryLenda;
            _klasaRepositry = klasaRepositry;
        }
        public async Task RegjistroLenden(LendaDto lendaDto, CancellationToken token)
        {
            Klasa klasaLendes;

            var klasaEkziston = await _klasaRepositry.GetAll().FirstOrDefaultAsync(k => k.Emri == lendaDto.Klasa);
            if(klasaEkziston == null) 
            {
                var newKlas = new Klasa { Emri = lendaDto.Klasa, Kapaciteti = 40 };
                _klasaRepositry.Add(newKlas);
                await _klasaRepositry.SaveAsync(token);
                klasaLendes = newKlas;
            }
            else
            {
                klasaLendes = klasaEkziston;
            }

            var lenda = new Lendet { Emri = lendaDto.Emri, Klasa = klasaLendes };
            _lendetRepository.Add(lenda);
            await _lendetRepository.SaveAsync(token);
        }
    }
}
