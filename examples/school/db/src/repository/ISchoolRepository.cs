using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace db.repository{
    public interface ISchoolRepository{
        
        public Task<IEnumerable<Teacher>> getActiveTeachers();
        public Task<IEnumerable<Teacher>> getInactiveTeachers();
        public Task<double> computeTeacherEfficiency(Teacher teacher);
        public Task<double> computeClassApprobationRate(Class @class);
        public Task<double> computeSubjectApprobationRate(Class @class, Subject subject);
        public Task<Dictionary<bool, Subject>> getResume(Student student, Class @Class);

    }
}