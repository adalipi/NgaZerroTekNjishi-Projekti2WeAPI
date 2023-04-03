using KursiDatabase.Context;
using KursiDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursiDatabase.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> Get(int id, CancellationToken token)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(f => f.Id == id, token);
        }

        public IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
