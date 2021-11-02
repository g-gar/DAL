using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using DAL;
using DAL.definition;
using DataAccessLayer.dto;
using Drew.Util;
using Microsoft.Extensions.Logging;
using Model;

namespace DataAccessLayer.dao{
    public class ClassDao : AbstractDao<Class, int>{

        private readonly ILogger Logger;
        
        public ClassDao(IDatabaseConnectionPool databaseConnectionPool, ILogger logger) : base(databaseConnectionPool)
        {
            Logger = logger;
        }

        public override Class create(Class entity)
        {
            throw new NotImplementedException();
        }

        public override Class update(Class entity)
        {
            throw new NotImplementedException();
        }

        public override Class delete(Class entity)
        {
            throw new NotImplementedException();
        }

        public override Class findById(int id)
        {
            return databaseConnectionPool.execute<ClassDto, Class>(command =>
            {
                command.CommandText = String.Format(
                    "select c.id, cc.id, cc.name, t.id, t.name from classes c where id = {0} " +
                    "left join class_codes cc on cc.id = c.class_code_id " +
                    "left join teachers t on t.id = c.teacher_id", id
                );
                return new ClassDto(command.ExecuteReader(CommandBehavior.SingleRow));
            }).Result;
        }

        public override IEnumerable<Class> findAll()
        {
            return databaseConnectionPool.execute<IEnumerable<ClassDto>, IEnumerable<Class>>(command =>
            {
                IList<ClassDto> result = new List<ClassDto>();
                command.CommandText = String.Format(
                    "select c.id, cc.id, cc.name, t.id, t.name from classes c " +
                    "left join class_codes cc on cc.id = c.class_code_id " +
                    "left join teachers t on t.id = c.teacher_id"
                );
                DbDataReader reader = command.ExecuteReader(CommandBehavior.Default);

                bool end = false;
                while (!end)
                {
                    try
                    {   
                        ClassDto c = new ClassDto(reader);
                        result.Add(c);
                    }
                    catch (NullReferenceException)
                    {
                        end = true;
                    }
                }

                return result;
            }).Result;
        }

        public override IEnumerable<Class> find(params Filter[] filters)
        {
            throw new NotImplementedException();
        }
    }
}