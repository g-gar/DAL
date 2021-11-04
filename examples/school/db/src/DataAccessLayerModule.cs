using AutoMapper;
using DAL.definition;
using db.dao;
using db.dto;
using db.repository;
using Microsoft.Extensions.DependencyInjection;
using Model;

namespace db{
    public static class DataAccessLayerModule{
        public static IServiceCollection loadDataAccessLayerModule(this IServiceCollection services)
        {
            return services
                .AddSingleton<IDao<ClassCode, long>, ClassCodeDao>()
                .AddSingleton<IDao<Class, long>, ClassDao>()
                .AddSingleton<IDao<Principal, long>, PrincipalDao>()
                .AddSingleton<IDao<School, long>, SchoolDao>()
                .AddSingleton<IDao<Student, long>, StudentDao>()
                .AddSingleton<IDao<Subject, long>, SubjectDao>()
                .AddSingleton<IDao<Teacher, long>, TeacherDao>()
                .AddSingleton<ISchoolRepository, SchoolRepository>()
                .AddSingleton<IRepository<School>>(provider => (IRepository<School>) provider.GetService<ISchoolRepository>())
                .AddSingleton<IConfigurationProvider>(new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ClassCodeDto, ClassCode>();
                    cfg.CreateMap<ClassDto, Class>()
                        .ForMember(
                            c => c.code, 
                            opt => opt.MapFrom(src => new ClassCode(src.classCodeId, src.classCodeName))
                        )
                        .ForMember(
                            c => c.teacher,
                            opt => opt.MapFrom(src => new Teacher(src.teacherId, src.teacherName))
                        )
                        ;
                    cfg.CreateMap<PrincipalDto, Principal>();
                    cfg.CreateMap<SchoolDto, School>();
                    cfg.CreateMap<StudentDto, Student>();
                    cfg.CreateMap<SubjectDto, Subject>();
                    cfg.CreateMap<TeacherDto, Teacher>();
                }));
        }
    }
}