using AutoMapper;
using DAL.definition;

namespace DAL.implementation{
    public class AutoMapperDataMapper : IDataMapper {

        private readonly IMapper mapper;

        public AutoMapperDataMapper(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public R get<T, R>(T obj)
        {
            return this.mapper.Map<R>(obj);
        }
    }
}