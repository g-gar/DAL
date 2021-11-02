using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DAL.definition;
using DAL.implementation;
using DataAccessLayer;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Model;

namespace test{
    class Program{
        static void Main(string[] args)
        {
            IServiceProvider provider = new ServiceCollection()
                    .AddLogging(builder => builder.AddConsole())
                    .AddSingleton<ILogger>(provider => provider.GetService<ILogger<Program>>())
                    .loadDALModule()
                    .loadDataAccessLayerModule()
                    .AddTransient<IMapper>(provider => provider.GetService<IConfigurationProvider>().CreateMapper())
                    .AddSingleton<IDataMapper, AutoMapperDataMapper>()
                    .AddSingleton<IDatabaseConnectionPoolConfiguration>(new DatabaseConnectionPoolConfiguration(10))
                    .AddSingleton<Func<DbConnection>>(() => new SqliteConnection("Data Source=school.sqlite;"))
                    .BuildServiceProvider();
            
            IDao<Teacher, int> dao = provider.GetService<IDao<Teacher, int>>();
            Teacher teacher = dao.create(new Teacher($"teacher{new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()}", new List<Subject>()
            {
                new Subject(null, "subject2")
            }));
            IDao<Class, int> classDao = provider.GetService<IDao<Class, int>>();
            IEnumerable<Class> classes = classDao.findAll();
            foreach (Class c in classes)
            {
                Console.WriteLine($"{c.id} {c.code.id} {c.code.name} {c.teacher.id} {c.teacher.name}");
            }
            int a = 0;
        }
    }
}