using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DAL.definition;
using Drew.Util;
using Microsoft.Extensions.Logging;
using Model;

namespace DataAccessLayer.dao{
    public class StudentDao : AbstractDao<Student, int>{

        private readonly ILogger logger;
        
        public StudentDao(IDatabaseConnectionPool databaseConnectionPool, ILogger logger) : base(databaseConnectionPool)
        {
            this.logger = logger;
        }

        public override Student create(Student entity)
        {
            throw new NotImplementedException();
        }

        public override Student update(Student entity)
        {
            throw new NotImplementedException();
        }

        public override Student delete(Student entity)
        {
            throw new NotImplementedException();
        }

        public override Student findById(int id)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Student> findAll()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Student> find(params Filter[] filters)
        {
            throw new NotImplementedException();
        }
    }
}