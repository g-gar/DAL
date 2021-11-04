using System.Collections.Generic;
using System.Threading.Tasks;
using Drew.Util;

namespace DAL.definition {
    public interface IDao<T, in ID>{
        public Task<T> create(T entity);
        public Task<T> update(T entity);
        public Task<bool> delete(T entity);
        public Task<T> findById(ID id);
        public Task<IEnumerable<T>> findAll();
        public Task<IEnumerable<T>> find(Filter filter);
    }
}