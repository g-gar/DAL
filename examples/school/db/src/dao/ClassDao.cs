using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.definition;
using db.dto;
using Drew.Util;
using Microsoft.Extensions.Logging;
using Model;

namespace db.dao{
    public class ClassDao : AbstractDao<Class, long>{

        private readonly ILogger Logger;
        
        public ClassDao(IDatabaseConnectionPool databaseConnectionPool, ILogger logger) : base(databaseConnectionPool)
        {
            Logger = logger;
        }

        public override async Task<Class> create(Class entity)
        {
            return await await await databaseConnectionPool.execute(command =>
            {
                command.CommandText = $"insert into classes(class_code_id, teacher_id) values ('{entity.code.id}', '{entity.teacher.id}'); select last_insert_rowid();";
                return (long?) command.ExecuteScalar();
            }).ContinueWith(async task => (await task).HasValue ? findById((await task).Value) : throw new NullReferenceException());
        }

        public override async Task<Class> update(Class entity)
        {
            return await await await databaseConnectionPool.execute(command =>
            {
                command.CommandText = $"update classes set class_code_id = '{entity.code.id}', teacher_id = '{entity.teacher.id}' where classes.id = '{entity.id}'; select last_insert_rowid();";
                return (long?) command.ExecuteScalar();
            }).ContinueWith(async task => (await task).HasValue ? findById((await task).Value) : throw new NullReferenceException());throw new NotImplementedException();
        }

        public override async Task<bool> delete(Class entity)
        {
            return await await databaseConnectionPool.execute(command =>
            {
                command.CommandText = $"delete from classes where id = '{entity.id}';";
                return command.ExecuteNonQuery();
            }).ContinueWith(async task => await task > 0);
        }

        public override async Task<Class> findById(long id)
        {
            return await databaseConnectionPool.execute<ClassDto, Class>(command =>
            {
                command.CommandText = String.Format(
                    "select c.id, cc.id, cc.name, t.id, t.name from classes c " +
                    "left join class_codes cc on cc.id = c.class_code_id " +
                    "left join teachers t on t.id = c.teacher_id " +
                    "where c.id = {0}", id
                );
                return new ClassDto(command.ExecuteReader(CommandBehavior.SingleRow));
            });
        }

        public override async Task<IEnumerable<Class>> findAll()
        {
            return await find(Filter.CreateEmpty());
        }

        public override async Task<IEnumerable<Class>> find(Filter filter)
        {
            return await databaseConnectionPool.execute<IEnumerable<Class>>(command =>
            {
                IList<Class> result = new List<Class>();
                command.CommandText = $"SELECT id FROM classes {(filter.HasExpression?$"WHERE {filter.GetExpressionString()}":"")}";
                DbDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                while (reader.Read()) result.Add(findById(reader.GetInt64(0)).Result);
                return result;
            });
        }
    }
}