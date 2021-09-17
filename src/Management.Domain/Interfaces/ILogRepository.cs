using System.Threading.Tasks;

namespace Management.Domain.Interfaces
{
    public interface ILogRepository
    {
        Task LogAsync(Log log);
    }
}
