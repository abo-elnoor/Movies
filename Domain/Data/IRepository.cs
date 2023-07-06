using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public interface IRepository<T> where T : class
    {
        IList<T> Table { get; }
        T GetById(object id);
        T Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
