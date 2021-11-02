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

        public abstract T create(T entity);

        public abstract T update(T entity);

        public abstract T delete(T entity);

        public abstract T findById(ID id);

        public abstract IEnumerable<T> findAll();

        public abstract IEnumerable<T> find(params Filter[] filters);
    }
}