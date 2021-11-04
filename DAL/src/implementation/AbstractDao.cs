using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.definition;
using Drew.Util;

namespace DAL {
    public abstract class AbstractDao<T, ID> : IDao<T, ID>{

        protected readonly IDatabaseConnectionPool databaseConnectionPool;

        protected AbstractDao(IDatabaseConnectionPool databaseConnectionPool)
        {
            this.databaseConnectionPool = databaseConnectionPool;
        }

        public abstract Task<T> create(T entity);

        public abstract Task<T> update(T entity);

        public abstract Task<bool> delete(T entity);

        public abstract Task<T> findById(ID id);

        public abstract Task<IEnumerable<T>> findAll();

        public abstract Task<IEnumerable<T>> find(Filter filter);
    }
}