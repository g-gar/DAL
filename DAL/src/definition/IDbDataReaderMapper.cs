using System.Data.Common;

namespace DAL.definition{
    public interface IDbDataReaderMapper{

        public R get<R>(DbDataReader reader);

    }
}