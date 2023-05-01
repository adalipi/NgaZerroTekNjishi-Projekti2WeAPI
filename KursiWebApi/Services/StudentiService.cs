using KursiDatabase.Models;
using KursiDatabase.Repository;
using KursiWebApi.DTOs;
using KursiWebApi.Mapper;
using Microsoft.EntityFrameworkCore;

namespace KursiWebApi.Services
{
    public class StudentiService : IStudentiService
    {
        private readonly IRepository<Studenti> _repository;

        public StudentiService(IRepository<Studenti> repository)
        {
            _repository = repository;
        }

        public async Task<Studenti?> GjejStudentinPermesEmailit(string email, CancellationToken token)
        {
            return await _repository.GetAll().FirstOrDefaultAsync(x => x.Email == email, token);
        }

        public async Task<IEnumerable<StudentiDto>> GjitheStudentet(CancellationToken token)
        {
            var studentet =  await _repository.GetAll().ToListAsync(token);

            return StudentiMapper.ToDTOs(studentet);
        }

        public async Task RegjistroStudentin(StudentiDto studenti, CancellationToken token)
        {
            var student = StudentiMapper.ToModel(studenti);
            student.Fjalkalimi = BCrypt.Net.BCrypt.HashPassword(student.Fjalkalimi);
            _repository.Add(student);
            await _repository.SaveAsync(token);
        }
    }
}