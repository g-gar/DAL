using System.Collections.Generic;
using System.Threading.Tasks;
using DAL;
using DAL.definition;
using Drew.Util;
using Microsoft.Extensions.Logging;
using Model;

namespace db.dao{
    public class StudentDao : AbstractDao<Student, long>{

        private readonly ILogger logger;

        public StudentDao(IDatabaseConnectionPool databaseConnectionPool, ILogger logger) : base(databaseConnectionPool)
        {
            this.logger = logger;
        }

        public override Task<Student> create(Student entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task<Student> update(Student entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task<bool> delete(Student entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task<Student> findById(long id)
        {
            throw new System.NotImplementedException();
        }

        public override Task<IEnumerable<Student>> findAll()
        {
            throw new System.NotImplementedException();
        }

        public override Task<IEnumerable<Student>> find(Filter filter)
        {
            throw new System.NotImplementedException();
        }
    }
}