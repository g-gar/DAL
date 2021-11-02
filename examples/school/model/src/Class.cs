using System.Collections.Generic;

namespace Model{
    public class Class{
        public int id { get; set; }
        public ClassCode code { get; set; }
        public Teacher teacher { get; set; }
        public IList<Student> students { get; set; }
        public IList<Subject> subjects { get; set; }

        public Class()
        {
        }

        public Class(int id, ClassCode code, Teacher teacher, IList<Student> students, IList<Subject> subjects)
        {
            this.id = id;
            this.code = code;
            this.teacher = teacher;
            this.students = students;
            this.subjects = subjects;
        }
    }
}