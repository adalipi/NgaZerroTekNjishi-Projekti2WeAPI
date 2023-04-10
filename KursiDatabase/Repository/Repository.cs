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
            _context.Add(entity);
        }

        public async Task Delete(int id, CancellationToken token)
        {
            var objToRemove = await Get(id, token);
            _context.Remove(objToRemove);
        }

        public async Task<T?> Get(int id, CancellationToken token)
        {
            //return await _context.Set<T>().FirstOrDefaultAsync(f => f.Id == id, token);

            throw new NotImplementedException("nuk eshte implementuar");
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task SaveAsync(CancellationToken token)
        {
           await _context.SaveChangesAsync(token);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
