using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{

    public interface IRepository<TModel> where TModel : class
    {
        IEnumerable<TModel> GetAll();
        TModel? Get(Expression<Func<TModel, bool>> expression);
        void Add(TModel entity);
        void Update(TModel entity);
        void Remove(TModel entity);
        void RemoveRange(IEnumerable<TModel> entity);
    }

    

}
