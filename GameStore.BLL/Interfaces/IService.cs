using System.Threading.Tasks;

namespace GameStore.BLL.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}