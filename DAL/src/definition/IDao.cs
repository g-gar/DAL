using System.Collections.Generic;
using System.Threading.Tasks;
using Drew.Util;

namespace DAL.definition {
    public interface IDao<T, in ID>{
        public T create(T entity);
        public T update(T entity);
        public T delete(T entity);
        public T findById(ID id);
        public IEnumerable<T> findAll();
        public IEnumerable<T> find(params Filter[] filters);
    }
}