namespace Management.Domain.Interfaces
{
    public interface IRepository<T>
    {
        void Insert(T obj);
        T Get(int Id);
    }
}
