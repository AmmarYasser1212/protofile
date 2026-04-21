using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Application.Interfaces.Repositories
{
    public interface Irepsitory<TEntity> where TEntity : class
    {
        ValueTask<TEntity> AddAsync(TEntity entity);

        ValueTask<TEntity?> GetByIdAsync(object id);

        ValueTask<IEnumerable<TEntity>> GetAllAsync();

        ValueTask<bool> DeleteAsync(object id);

        Task<bool> UpdateAsync(TEntity entity);

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();


        

    }
}
