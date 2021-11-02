using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DAL.definition;
using Drew.Util;
using Microsoft.Extensions.Logging;
using Model;

namespace DataAccessLayer.dao{
    public class SchoolDao : AbstractDao<School, int>{

        private readonly ILogger logger;
        
        public SchoolDao(IDatabaseConnectionPool databaseConnectionPool, ILogger logger) : base(databaseConnectionPool)
        {
            this.logger = logger;
        }

        public override School create(School entity)
        {
            throw new NotImplementedException();
        }

        public override School update(School entity)
        {
            throw new NotImplementedException();
        }

        public override School delete(School entity)
        {
            throw new NotImplementedException();
        }

        public override School findById(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<School> findAll()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<School> find(params Filter[] filters)
        {
            throw new NotImplementedException();
        }
    }
}