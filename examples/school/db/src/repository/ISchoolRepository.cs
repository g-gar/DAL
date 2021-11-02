using System.Collections.Generic;
using Model;

namespace DataAccessLayer.repository{
    public interface ISchoolRepository{
        
        public IEnumerable<Teacher> getActiveTeachers();
        public IEnumerable<Teacher> getInactiveTeachers();
        public double computeTeacherEfficiency(Teacher teacher);
        public double computeClassApprobationRate(Class @class);
        public double computeSubjectApprobationRate(Class @class, Subject subject);
        public Dictionary<bool, Subject> getResume(Student student, Class @Class);

    }
}