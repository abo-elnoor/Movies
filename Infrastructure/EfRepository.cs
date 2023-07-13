using Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _context;
        private DbSet<T> _entities;

        public EfRepository(IDbContext context)
        {
            this._context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.Entities.FindAsync(id);
        }

        public async Task<T> InsertAsync(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                await this.Entities.AddAsync(entity);
                await this._context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await this._context.Set<T>().ToListAsync();
        }

        public IQueryable<T> Table
        {
            get
            {
                return this._context.Set<T>().AsQueryable();
            }
        }

        public async Task<int> UpdateAsync(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                return await this._context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> DeleteAsync(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Remove(entity);

                return await this._context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }      

        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
    }
}
