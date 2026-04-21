using Microsoft.EntityFrameworkCore;
using PMS.Application.Interfaces.Repositories;
using PMS.Infrastructre.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Infrastructre.Repository
{
    public class ReposetoryGeneric<TEntity> : Irepsitory<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        private DbSet<TEntity> _entity;
        public ReposetoryGeneric(AppDbContext context)
        {

            _context = context;

            _entity = _context.Set<TEntity>();


        }
        public async ValueTask<TEntity> AddAsync(TEntity entity)
        {
            await _entity.AddAsync(entity);//return EntityEntry<TEntity>
            await _context.SaveChangesAsync();
            return entity;
        }

        public async ValueTask<bool> DeleteAsync(object id)
        {
            var oData = await _entity.FindAsync(id);
            if (oData == null)
                return false;

            _entity.Remove(oData);
            SaveChanges();
            return true;
        }

        public ValueTask<TEntity?> GetByIdAsync(object id)
        {
            return _entity.FindAsync(id);


        }

        public async ValueTask<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entity.ToListAsync();
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            _entity.Update(entity);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<bool> ExistsAsync(
                Expression<Func<TEntity, bool>> predicate)
        {
            return await _entity.AnyAsync(predicate);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
