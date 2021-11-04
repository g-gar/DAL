using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DAL.definition;
using DAL.implementation;
using db;
using db.repository;
using Drew.Util;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Model;

namespace test{
    class Program{
        static async Task Main(string[] args)
        {
            IServiceProvider provider = new ServiceCollection()
                    .AddLogging(builder => builder.AddConsole())
                    .AddSingleton<ILogger>(provider => provider.GetService<ILogger<Program>>())
                    .loadDALModule()
                    .loadDataAccessLayerModule()
                    .AddTransient<IMapper>(provider => provider.GetService<IConfigurationProvider>().CreateMapper())
                    .AddSingleton<IDataMapper, AutoMapperDataMapper>()
                    .AddSingleton<IDatabaseConnectionPoolConfiguration>(new DatabaseConnectionPoolConfiguration(10, $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}/Desktop/school.sqlite"))
                    .AddSingleton<Func<IDatabaseConnectionPoolConfiguration, DbConnection>>(config => new SqliteConnection($"Data Source={config.path};"))
                    .BuildServiceProvider();
            
            // IDao<Teacher, long> dao = provider.GetService<IDao<Teacher, long>>();
            // Teacher teacher = await dao.create(new Teacher($"teacher{new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()}", new List<Subject>()
            // {
            //     new Subject(null, "subject2")
            // }));
            // IDao<Class, long> classDao = provider.GetService<IDao<Class, long>>();
            // foreach (Class c in await classDao.findAll())
            // {
            //     Console.WriteLine($"{c.id} {c.code.id} {c.code.name} {c.teacher.id} {c.teacher.name}");
            // }
            //
            // foreach (Teacher t in await dao.findAll())
            // {
            //     Console.WriteLine($"{t.id} {t.name}");
            // }

            ISchoolRepository repository = provider.GetService<ISchoolRepository>();
            foreach (Teacher t in await repository.getActiveTeachers())
            {
                Console.WriteLine($"{t.id} {t.name}");
            }

            int a = 0;
        }
    }
}