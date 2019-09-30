using System.Threading.Tasks;

namespace GameStore.BLL.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}