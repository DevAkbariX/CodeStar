using CodeStar.Application.Interfaces.Repository;
using CodeStar.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStar.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CodeStarDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(CodeStarDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

  

        public async Task<T> GetByIdAsync(long id)
        {
            try
            {

              return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                throw;
            }
        }



        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
