using DamlaProje.Blog.DataAccess.Concrete.EntityFrameworkCore.Context;
using DamlaProje.Blog.DataAccess.Interfaces;
using DamlaProje.Blog.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DamlaProje.Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntiy> : IGenericDal<TEntiy> where TEntiy : class, ITable, new()
    {
        private readonly BlogContext _context;
        public EfGenericRepository(BlogContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TEntiy entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntiy> FindByIdAsync(int id)
        {
            return await _context.FindAsync<TEntiy>(id);
        }

        public async Task<List<TEntiy>> GetAllAsync()
        {
            return await _context.Set<TEntiy>().ToListAsync();
        }

        public async Task<List<TEntiy>> GetAllAsync(Expression<Func<TEntiy, bool>> filter)
        {
            return await _context.Set<TEntiy>().Where(filter).ToListAsync();
        }
        public async Task<List<TEntiy>> GetAllAsync<TKey>(Expression<Func<TEntiy, bool>> filter, Expression<Func<TEntiy, TKey>> keySelector)
        {
            return await _context.Set<TEntiy>().Where(filter).OrderByDescending(keySelector).ToListAsync();
        }
        public async Task<List<TEntiy>> GetAllAsync<TKey>(Expression<Func<TEntiy, TKey>> keySelector)
        {
            return await _context.Set<TEntiy>().OrderByDescending(keySelector).ToListAsync();
        }
        public async Task<TEntiy> GetAsync(Expression<Func<TEntiy, bool>> filter)
        {
            return await _context.Set<TEntiy>().FirstOrDefaultAsync(filter);
        }

        public async Task RemoveAsync(TEntiy entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntiy entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
