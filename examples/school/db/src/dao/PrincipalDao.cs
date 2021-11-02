using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DAL.definition;
using Drew.Util;
using Microsoft.Extensions.Logging;
using Model;

namespace DataAccessLayer.dao{
    public class PrincipalDao : AbstractDao<Principal, int>{

        private readonly ILogger logger;
        
        public PrincipalDao(IDatabaseConnectionPool databaseConnectionPool, ILogger logger) : base(databaseConnectionPool)
        {
            this.logger = logger;
        }

        public override Principal create(Principal entity)
        {
            throw new NotImplementedException();
        }

        public override Principal update(Principal entity)
        {
            throw new NotImplementedException();
        }

        public override Principal delete(Principal entity)
        {
            throw new NotImplementedException();
        }

        public override Principal findById(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Principal> findAll()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Principal> find(params Filter[] filters)
        {
            throw new NotImplementedException();
        }
    }
}