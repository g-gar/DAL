using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DAL.definition;
using Drew.Util;
using Microsoft.Extensions.Logging;
using Model;

namespace db.dao{
    public class ClassCodeDao : AbstractDao<ClassCode, long>{

        private readonly ILogger logger;

        public ClassCodeDao(IDatabaseConnectionPool databaseConnectionPool, ILogger logger) : base(databaseConnectionPool)
        {
            this.logger = logger;
        }

        public override Task<ClassCode> create(ClassCode entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task<ClassCode> update(ClassCode entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task<bool> delete(ClassCode entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task<ClassCode> findById(long id)
        {
            throw new System.NotImplementedException();
        }

        public override Task<IEnumerable<ClassCode>> findAll()
        {
            throw new System.NotImplementedException();
        }

        public override Task<IEnumerable<ClassCode>> find(Filter filter)
        {
            throw new System.NotImplementedException();
        }
    }
}