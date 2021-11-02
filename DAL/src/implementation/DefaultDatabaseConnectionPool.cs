using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Internal;
using DAL.definition;

namespace DAL.implementation{
    public class DefaultDatabaseConnectionPool : IDatabaseConnectionPool{

        private readonly IDatabaseConnectionPoolConfiguration configuration;
        private readonly IDataMapper mapper;
        private readonly Dictionary<int, DbConnection> connections;
        // TODO: add a queue for jobs

        public DefaultDatabaseConnectionPool(IDatabaseConnectionPoolConfiguration configuration, IDataMapper mapper, Func<DbConnection> fn)
        {
            this.configuration = configuration;
            this.mapper = mapper;
            this.connections = new Dictionary<int, DbConnection>();
            Enumerable.Range(0, configuration.amount - 1).ForAll(n =>
            {
                connections[n] = fn.Invoke();
                connections[n].Open();
            });
        }

        public async Task<R> execute<T, R>(Func<DbCommand, T> fn)
        {
            DbConnection connection = await this.get();
            return await Task.Run<R>(()=> mapper.get<T, R>(fn.Invoke(connection.CreateCommand())));
        }

        public async Task execute(Action<DbCommand> fn)
        {
            DbConnection connection = await this.get();
            await Task.Run(()=> fn.Invoke(connection.CreateCommand()));
        }

        private async Task<DbConnection> get()
        {
            return await Task.Run(new Func<DbConnection>((() =>
            {
                DbConnection result = null, connection = null;
                int i = 0, max = connections.Count;
                while (result == null)
                {
                    if (i == max - 1) i = 0;
                    connection = this.connections[i];
                    if (connection.State == ConnectionState.Open)
                    {
                        result = connection;
                    }
                }

                return result;
            })));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            foreach(DbConnection connection in connections.Values)
            {
                connection.Close();
            }
        }
        
        ~DefaultDatabaseConnectionPool()
        {
            Dispose(false);
        }
        
    }
}