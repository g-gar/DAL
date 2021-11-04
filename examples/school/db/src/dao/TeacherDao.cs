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
    public class TeacherDao : AbstractDao<Teacher, long>{

        private readonly ILogger logger;

        public TeacherDao(IDatabaseConnectionPool databaseConnectionPool, ILogger logger) : base(databaseConnectionPool)
        {
            this.logger = logger;
        }

        public override async Task<Teacher> create(Teacher entity)
        {
            return await await await databaseConnectionPool.execute(command =>
            {
                command.CommandText = $"insert into teachers(name) values ('{entity.name}'); select last_insert_rowid();";
                return (long?) command.ExecuteScalar();
            }).ContinueWith(async task => (await task).HasValue ? findById((await task).Value) : throw new NullReferenceException());
        }

        public override async Task<Teacher> update(Teacher entity)
        {
            return await await await databaseConnectionPool.execute(command =>
            {
                command.CommandText = $"update teachers set name = '{entity.name}' where id = '{entity.id}';";
                return command.ExecuteNonQuery();
            }).ContinueWith(async task => await task > 0 ? findById(await task) : throw new NullReferenceException());
        }

        public override async Task<bool> delete(Teacher entity)
        {
            return await await databaseConnectionPool.execute(command =>
            {
                command.CommandText = $"delete from teachers where id = '{entity.id}';";
                return command.ExecuteNonQuery();
            }).ContinueWith(async task => await task > 0);
        }

        public override async Task<Teacher> findById(long id)
        {
            return await databaseConnectionPool.execute<TeacherDto, Teacher>(command =>
            {
                command.CommandText = $"select id, name from teachers where id = {id}";
                return new TeacherDto(command.ExecuteReader(CommandBehavior.SingleRow));
            });
        }

        public override async Task<IEnumerable<Teacher>> findAll()
        {
            return await find(Filter.CreateEmpty());
        }

        public override async Task<IEnumerable<Teacher>> find(Filter filter)
        {
            return await databaseConnectionPool.execute<IEnumerable<Teacher>>(command =>
            {
                IList<Teacher> result = new List<Teacher>();
                command.CommandText = $"SELECT id FROM teachers {(filter.HasExpression?$"WHERE {filter.GetExpressionString()}":"")}";
                DbDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);
                while (reader.Read()) result.Add(findById(reader.GetInt64(0)).Result);
                return result;
            });
        }
    }
}