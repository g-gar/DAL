using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using DAL.definition;
using db.dto;
using Microsoft.Extensions.Logging;
using Model;

namespace db.repository{
    public class SchoolRepository : IRepository<School>, ISchoolRepository{

        private readonly IDatabaseConnectionPool connectionPool;
        private readonly ILogger logger;
        
        private readonly IDao<ClassCode, long> classCodeDao;
        private readonly IDao<Class, long> classDao;
        private readonly IDao<Principal, long> principalDao;
        private readonly IDao<School, long> schoolDao;
        private readonly IDao<Student, long> studentDao;
        private readonly IDao<Subject, long> subjectDao;
        private readonly IDao<Teacher, long> teacherDao;

        public SchoolRepository(IDatabaseConnectionPool connectionPool, ILogger logger, IDao<ClassCode, long> classCodeDao, IDao<Class, long> classDao, IDao<Principal, long> principalDao, IDao<School, long> schoolDao, IDao<Student, long> studentDao, IDao<Subject, long> subjectDao, IDao<Teacher, long> teacherDao)
        {
            this.connectionPool = connectionPool;
            this.logger = logger;
            this.classCodeDao = classCodeDao;
            this.classDao = classDao;
            this.principalDao = principalDao;
            this.schoolDao = schoolDao;
            this.studentDao = studentDao;
            this.subjectDao = subjectDao;
            this.teacherDao = teacherDao;
        }

        public async Task<IEnumerable<Teacher>> getActiveTeachers()
        {
            return await connectionPool.execute<IEnumerable<Teacher>>( command =>
            {
                IList<Teacher> result = new List<Teacher>();
                command.CommandText = "select t.id from classes c left join teachers t on c.teacher_id = t.id";
                DbDataReader reader = command.ExecuteReader();
                while (reader.Read()) result.Add(teacherDao.findById(reader.GetInt64(0)).Result); //TODO: make asynchronous
                return result;
            });
        }

        public Task<IEnumerable<Teacher>> getInactiveTeachers()
        {
            throw new System.NotImplementedException();
        }

        public Task<double> computeTeacherEfficiency(Teacher teacher)
        {
            throw new System.NotImplementedException();
        }

        public Task<double> computeClassApprobationRate(Class @class)
        {
            throw new System.NotImplementedException();
        }

        public Task<double> computeSubjectApprobationRate(Class @class, Subject subject)
        {
            throw new System.NotImplementedException();
        }

        public Task<Dictionary<bool, Subject>> getResume(Student student, Class Class)
        {
            throw new System.NotImplementedException();
        }
    }
}