using DAL.definition;

namespace DAL.implementation{
    public class DatabaseConnectionPoolConfiguration : IDatabaseConnectionPoolConfiguration{
        public int amount { get; }
        
        public DatabaseConnectionPoolConfiguration(int amount)
        {
            this.amount = amount;
        }
    }
}