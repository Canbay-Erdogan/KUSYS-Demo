using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KusysDemo.DAL
{
    public class KusysRepository<T> : IRepository<T> where T : class, new()
    {
        private readonly KusysContext _context;

        public KusysRepository(KusysContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> ListData()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
