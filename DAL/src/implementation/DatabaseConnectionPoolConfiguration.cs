using System;
using DAL.definition;

namespace DAL.implementation{
    public class DatabaseConnectionPoolConfiguration : IDatabaseConnectionPoolConfiguration{
        public int amount { get; }
        public string path { get; }

        public DatabaseConnectionPoolConfiguration(int amount, string path)
        {
            this.amount = amount;
            this.path = path;
        }
    }
}