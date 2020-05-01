using System.Threading.Tasks;

namespace IotHub.Repositories.Base
{
    public interface IBaseRepository<T>
    {
        Task<T> CreateAsync(T entity);
        Task<T> GetAsync(string id);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string id);
    }
}
