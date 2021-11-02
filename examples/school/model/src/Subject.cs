namespace Model{
    public class Subject{
        public int? id { get; set; }
        public string name { get; set; }

        public Subject()
        {
        }

        public Subject(int? id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}