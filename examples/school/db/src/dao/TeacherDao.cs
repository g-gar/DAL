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
    public class TeacherDao : AbstractDao<Teacher, int>{

        private readonly ILogger logger;

        public TeacherDao(IDatabaseConnectionPool databaseConnectionPool, ILogger logger) : base(databaseConnectionPool)
        {
            this.logger = logger;
        }

        public override Teacher create(Teacher entity)
        {
            return databaseConnectionPool.execute<TeacherDto, Teacher>(command =>
            {
                TeacherDto result = default(TeacherDto);
                command.CommandText = String.Format("insert into teachers(name) values ('{0}'); select last_insert_rowid();", entity.name);
                long? id = (long?) command.ExecuteScalar();
                if (id.HasValue)
                {
                    command.CommandText = String.Format("select id, name from teachers where id = {0}", id);
                    result = new TeacherDto(command.ExecuteReader(CommandBehavior.SingleRow));
                } // TODO: throw exception?
                return result;
            }).Result;
        }

        public override Teacher update(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public override Teacher delete(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public override Teacher findById(int id)
        {
            return databaseConnectionPool.execute<TeacherDto, Teacher>(command =>
            {
                command.CommandText = String.Format("select id, name from teachers where id = {0}", id);
                return new TeacherDto(command.ExecuteReader(CommandBehavior.SingleRow));
            }).Result;
        }

        public override IEnumerable<Teacher> findAll()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Teacher> find(params Filter[] filters)
        {
            throw new NotImplementedException();
        }
    }
}