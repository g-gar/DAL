namespace Model{
    public class ClassCode{
        
        public int? id { get; set; }
        public string name { get; set; }

        public ClassCode()
        {
        }

        public ClassCode(string name)
        {
            this.name = name;
        }

        public ClassCode(int? id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}