namespace Model{
    public class ClassCode{
        
        public long? id { get; set; }
        public string name { get; set; }

        public ClassCode()
        {
        }

        public ClassCode(string name)
        {
            this.name = name;
        }

        public ClassCode(long? id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}