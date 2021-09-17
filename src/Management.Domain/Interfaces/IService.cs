using System.Collections.Generic;

namespace Management.Domain.Interfaces
{
    public interface IService<T>
    {
        void Insert(T obj);
        List<T> Get();
        T Get(int id);
        bool Delete(int id);
        bool Update(T employee, int id);
    }
}
