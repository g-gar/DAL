using System.Collections.Generic;

namespace Model{
    public class Teacher{
        public int? id { get; set; }
        public string name { get; set; }
        public IList<Subject> subjects { get; set; }

        public Teacher()
        {
            
        }

        public Teacher(int? id, string name, IList<Subject> subjects)
        {
            this.id = id;
            this.name = name;
            this.subjects = subjects;
        }
        
        public Teacher( string name, IList<Subject> subjects)
        {
            this.id = null;
            this.name = name;
            this.subjects = subjects;
        }
    }
}