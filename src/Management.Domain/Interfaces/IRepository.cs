using System.Collections.Generic;

namespace Management.Domain.Interfaces
{
    public interface IRepository<T>
    {
        void Insert(T obj);
        List<T> Get();
        T Get(int id);
        bool Delete(int id);
        bool Update(T employee, int id);
    }
}
