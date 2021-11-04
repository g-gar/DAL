using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace DAL.definition {
    public interface IDatabaseConnectionPool : IDisposable {
        
        public Task<R> execute<T, R>(Func<DbCommand, T> fn);

        public Task<R> execute<R>(Func<DbCommand, R> fn);
        public Task execute(Action<DbCommand> fn);

        // public Task<DbConnection> get();

    }
}