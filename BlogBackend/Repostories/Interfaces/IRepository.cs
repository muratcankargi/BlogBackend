namespace BlogBackend.Repostories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Create(T entity);
        IReadOnlyList<T> GetAll();
        T GetById(int id);
        void Update(T entity);
        void Delete(T entity);
    }
}
