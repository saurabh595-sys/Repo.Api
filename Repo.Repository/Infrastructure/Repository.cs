using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Repository.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Contex _contex;
        public Repository(Contex contex)
        {
            _contex = contex;
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _contex.Set<T>().ToListAsync();

        }

        public async Task<T> GetById(int id)
        {
            return await _contex.Set<T>().FindAsync(id);
        }
        public async Task<bool> Add(T entity)
        {
            await _contex.AddAsync(entity);
           await _contex.SaveChangesAsync();
            return true;
        }
        public async Task Update(T entity)
        {
            _contex.Entry(entity).State = EntityState.Modified;
            _contex.Set<T>().Update(entity);
            await _contex.SaveChangesAsync();
        }

        

        public async Task Delete(T entity)
        {
            _contex.Set<T>().Remove(entity);
           await _contex.SaveChangesAsync();
        }

       
    }
}
