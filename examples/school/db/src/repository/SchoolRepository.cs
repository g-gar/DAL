using System.Collections.Generic;
using DAL.definition;
using Microsoft.Extensions.Logging;
using Model;

namespace DataAccessLayer.repository{
    public class SchoolRepository : IRepository<School>, ISchoolRepository {

        private readonly ILogger logger;
        
        private readonly IDao<ClassCode, int> classCodeDao;
        private readonly IDao<Class, int> classDao;
        private readonly IDao<Principal, int> principalDao;
        private readonly IDao<School, int> schoolDao;
        private readonly IDao<Student, int> studentDao;
        private readonly IDao<Subject, int> subjectDao;
        private readonly IDao<Teacher, int> teacherDao;

        public SchoolRepository(ILogger logger, IDao<ClassCode, int> classCodeDao, IDao<Class, int> classDao, IDao<Principal, int> principalDao, IDao<School, int> schoolDao, IDao<Student, int> studentDao, IDao<Subject, int> subjectDao, IDao<Teacher, int> teacherDao)
        {
            this.logger = logger;
            this.classCodeDao = classCodeDao;
            this.classDao = classDao;
            this.principalDao = principalDao;
            this.schoolDao = schoolDao;
            this.studentDao = studentDao;
            this.subjectDao = subjectDao;
            this.teacherDao = teacherDao;
        }

        public IEnumerable<Teacher> getActiveTeachers()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Teacher> getInactiveTeachers()
        {
            throw new System.NotImplementedException();
        }

        public double computeTeacherEfficiency(Teacher teacher)
        {
            throw new System.NotImplementedException();
        }

        public double computeClassApprobationRate(Class @class)
        {
            throw new System.NotImplementedException();
        }

        public double computeSubjectApprobationRate(Class @class, Subject subject)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<bool, Subject> getResume(Student student, Class Class)
        {
            throw new System.NotImplementedException();
        }
    }
}