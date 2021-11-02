namespace DAL.definition {
    public interface IDataMapper{

        R get<T, R>(T obj);

    }
}