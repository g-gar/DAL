namespace DAL.definition{
    public interface IDatabaseConnectionPoolConfiguration{
        public int amount { get; }
        public string path { get; }
    }
}