using System.Threading.Tasks;

namespace Shared.Domain
{
    public interface IRepository
    {
    }
    public interface IRepository<T, in TKey> : IRepository where T : class 
    {
        Task Create(T entity);
        Task<T> GetBy(TKey id);
        Task Update(T entity);
        Task Delete(T entity);
    }
}