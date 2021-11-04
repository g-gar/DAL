using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DAL.definition;
using Drew.Util;
using Microsoft.Extensions.Logging;
using Model;

namespace db.dao{
    public class PrincipalDao : AbstractDao<Principal, long>{

        private readonly ILogger logger;

        public PrincipalDao(IDatabaseConnectionPool databaseConnectionPool, ILogger logger) : base(databaseConnectionPool)
        {
            this.logger = logger;
        }

        public override Task<Principal> create(Principal entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task<Principal> update(Principal entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task<bool> delete(Principal entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task<Principal> findById(long id)
        {
            throw new System.NotImplementedException();
        }

        public override Task<IEnumerable<Principal>> findAll()
        {
            throw new System.NotImplementedException();
        }

        public override Task<IEnumerable<Principal>> find(Filter filter)
        {
            throw new System.NotImplementedException();
        }
    }
}