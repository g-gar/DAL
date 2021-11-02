using AutoMapper;
using DAL.definition;
using DataAccessLayer.dao;
using DataAccessLayer.dto;
using DataAccessLayer.repository;
using Microsoft.Extensions.DependencyInjection;
using Model;

namespace DataAccessLayer{
    public static class DataAccessLayerModule{
        public static IServiceCollection loadDataAccessLayerModule(this IServiceCollection services)
        {
            return services
                .AddSingleton<IDao<ClassCode, int>, ClassCodeDao>()
                .AddSingleton<IDao<Class, int>, ClassDao>()
                .AddSingleton<IDao<Principal, int>, PrincipalDao>()
                .AddSingleton<IDao<School, int>, SchoolDao>()
                .AddSingleton<IDao<Student, int>, StudentDao>()
                .AddSingleton<IDao<Subject, int>, SubjectDao>()
                .AddSingleton<IDao<Teacher, int>, TeacherDao>()
                .AddSingleton<IRepository<School>, SchoolRepository>()
                .AddSingleton<IConfigurationProvider>(new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ClassCodeDto, ClassCode>();
                    cfg.CreateMap<ClassDto, Class>()
                        .ForMember(
                            c => c.code, 
                            opt => opt.MapFrom(src => new ClassCodeDto(src.classCodeId, src.classCodeName))
                        )
                        .ForMember(
                            c => c.teacher,
                            opt => opt.MapFrom(src => new TeacherDto(src.teacherId, src.teacherName))
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