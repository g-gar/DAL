using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DAL.definition;
using Drew.Util;
using Microsoft.Extensions.Logging;
using Model;

namespace db.dao{
    public class SubjectDao : AbstractDao<Subject, long>{

        private readonly ILogger logger;

        public SubjectDao(IDatabaseConnectionPool databaseConnectionPool, ILogger logger) : base(databaseConnectionPool)
        {
            this.logger = logger;
        }

        public override Task<Subject> create(Subject entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task<Subject> update(Subject entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task<bool> delete(Subject entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task<Subject> findById(long id)
        {
            throw new System.NotImplementedException();
        }

        public override Task<IEnumerable<Subject>> findAll()
        {
            throw new System.NotImplementedException();
        }

        public override Task<IEnumerable<Subject>> find(Filter filter)
        {
            throw new System.NotImplementedException();
        }
    }
}