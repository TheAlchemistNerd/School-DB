
namespace StudentRepository
{
    public interface IRepository<T>
    {
        void Save(T entity);
        List<T> GetAll();
    }
}
