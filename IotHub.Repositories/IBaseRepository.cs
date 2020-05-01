using System.Threading.Tasks;

namespace IotHub.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> GetAsync(string id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string id); 
    }
}
