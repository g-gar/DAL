using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DAL;
using DAL.definition;
using DataAccessLayer.dto;
using Drew.Util;
using Microsoft.Extensions.Logging;
using Model;

namespace DataAccessLayer.dao{
    public class ClassCodeDao : AbstractDao<ClassCode, int>{

        private readonly ILogger logger;
        
        public ClassCodeDao(IDatabaseConnectionPool databaseConnectionPool, ILogger logger) : base(databaseConnectionPool)
        {
            this.logger = logger;
        }

        public override ClassCode create(ClassCode entity)
        {
            throw new NotImplementedException();
        }

        public override ClassCode update(ClassCode entity)
        {
            throw new NotImplementedException();
        }

        public override ClassCode delete(ClassCode entity)
        {
            throw new NotImplementedException();
        }

        public override ClassCode findById(int id)
        {
            return databaseConnectionPool.execute<ClassCodeDto, ClassCode>(command =>
            {
                command.CommandText = String.Format("select id, name from class_codes where id = {0}", id);
                return new ClassCodeDto(command.ExecuteReader(CommandBehavior.SingleRow));
            }).Result;
        }

        public override IEnumerable<ClassCode> findAll()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ClassCode> find(params Filter[] filters)
        {
            throw new NotImplementedException();
        }
    }
}