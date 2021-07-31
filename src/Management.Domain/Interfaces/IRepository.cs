namespace Management.Domain.Interfaces
{
    public interface IRepository<T>
    {
        void Adicionar(T obj);
    }
}
