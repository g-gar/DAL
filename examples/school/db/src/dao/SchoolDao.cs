using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DAL.definition;
using Drew.Util;
using Microsoft.Extensions.Logging;
using Model;

namespace db.dao{
    public class SchoolDao : AbstractDao<School, long>{

        private readonly ILogger logger;

        public SchoolDao(IDatabaseConnectionPool databaseConnectionPool, ILogger logger) : base(databaseConnectionPool)
        {
            this.logger = logger;
        }

        public override Task<School> create(School entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task<School> update(School entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task<bool> delete(School entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task<School> findById(long id)
        {
            throw new System.NotImplementedException();
        }

        public override Task<IEnumerable<School>> findAll()
        {
            throw new System.NotImplementedException();
        }

        public override Task<IEnumerable<School>> find(Filter filter)
        {
            throw new System.NotImplementedException();
        }
    }
}