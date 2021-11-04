using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DAL.definition;
using Drew.Util;
using Microsoft.Extensions.Logging;
using Model;

namespace DataAccessLayer.dao{
    public class SubjectDao : AbstractDao<Subject, int>{

        private readonly ILogger logger;
        
        public SubjectDao(IDatabaseConnectionPool databaseConnectionPool, ILogger logger) : base(databaseConnectionPool)
        {
            this.logger = logger;
        }

        public override Subject create(Subject entity)
        {
            throw new NotImplementedException();
        }

        public override Subject update(Subject entity)
        {
            throw new NotImplementedException();
        }

        public override Subject delete(Subject entity)
        {
            throw new NotImplementedException();
        }

        public override Subject findById(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Subject> findAll()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Subject> find(params Filter[] filters)
        {
            throw new NotImplementedException();
        }
    }
}