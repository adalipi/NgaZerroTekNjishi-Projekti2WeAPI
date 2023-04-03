using KursiDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursiDatabase.Repository
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<T?> Get(int id, CancellationToken token);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        Task Delete(int id, CancellationToken token);
        Task SaveAsync(CancellationToken token);
    }
}
