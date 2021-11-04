using System.Collections.Generic;

namespace Model{
    public class Teacher{
        public long? id { get; set; }
        public string name { get; set; }
        public IList<Subject> subjects { get; set; }

        public Teacher()
        {
            
        }

        public Teacher(long? id, string name, IList<Subject> subjects)
        {
            this.id = id;
            this.name = name;
            this.subjects = subjects;
        }
        
        public Teacher(string name, IList<Subject> subjects)
        {
            this.id = default;
            this.name = name;
            this.subjects = subjects;
        }
        
        public Teacher(long? id, string name)
        {
            this.id = id;
            this.name = name;
            this.subjects = default;
        }
    }
}