using Microsoft.EntityFrameworkCore;

namespace VerifyApi.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T: class
    {
        private readonly DbContext _dbContext;
        public RepositoryBase(DbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Add<T>(entity);
            _dbContext.SaveChanges();
        }

        public T? Get(int id)
        {
            return _dbContext.Find<T>(id);
        }

        public IEnumerable<T> List()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }
    }
}
