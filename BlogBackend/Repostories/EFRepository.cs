using BlogBackend.AppContext;
using BlogBackend.Repostories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogBackend.Repostories
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<T> _set;
        public EFRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
            _set = _dbContext.Set<T>();
        }

        public T Create(T entity)
        {
            _set.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IReadOnlyList<T> GetAll()
        {
            return _set.ToList();
        }

        public async Task<T> GetById(int id)
        {
            return await _set.FindAsync(id);
        }

        public void Update(T entity)
        {
            _set.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
