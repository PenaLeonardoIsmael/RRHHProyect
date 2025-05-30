using Data.Data;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class RepositoryBase<TModel> : IRepository<TModel> where TModel : class
    {

        private readonly ApplicationDBContext _context;
        internal DbSet<TModel> _dbSet;
        public RepositoryBase(ApplicationDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<TModel>();
        }

        public void Add(TModel entity)
        {
            _dbSet.Add(entity);
        }

        public TModel? Get(Expression<Func<TModel, bool>> expression)
        {
            IQueryable<TModel> query = _dbSet;
            query = query.Where(expression);
            return query.FirstOrDefault();
        }

        public IEnumerable<TModel> GetAll()
        {
            return _dbSet.AsEnumerable();
        }
        public void Remove(TModel entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TModel> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(TModel entity)
        {
            _dbSet.Update(entity);
        }
    }
}
