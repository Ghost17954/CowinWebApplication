using Microsoft.EntityFrameworkCore;
using CoWin.Application.Contracts.Persistance;
using CoWin.Domain.Common;
using CoWin.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoWin.Infrastructure.Repository
{
    public class RepositoryBase <T>: IAsyncRepository<T> where T : EntityBase
    {
        protected readonly VaccinationContext _context;

        public RepositoryBase(VaccinationContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
           _context.Set<T>().Add(entity);
           await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
           _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }       

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
             await _context.SaveChangesAsync();
        }
    }
}
