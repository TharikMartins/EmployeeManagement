using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Domain.Interfaces
{
    public interface IService<T>
    {
        Task Insert(T obj);
        Task<List<T>> Get();
        Task<T> Get(int id);
        Task<bool> Delete(int id);
        Task<bool> Update(T employee, int id);
    }
}
