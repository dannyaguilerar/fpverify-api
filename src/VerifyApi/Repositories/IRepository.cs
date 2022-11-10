namespace VerifyApi.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T? Get(int id);
        IEnumerable<T> List();
    }
}
