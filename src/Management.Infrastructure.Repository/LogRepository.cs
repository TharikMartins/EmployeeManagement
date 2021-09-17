using Management.Domain;
using Management.Domain.Interfaces;
using Management.Infrastructure.Repository.Context;
using System;
using System.Threading.Tasks;

namespace Management.Infrastructure.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly EnterpriseContext _context;
        public LogRepository(EnterpriseContext context)
        {
            _context = context;
        }

        public async Task LogAsync(Log log)
        {
            await _context.Log.AddAsync(new DTO.LogDTO { EndpointName = log.EndpointName, MethodType = log.MethodType, 
                Message = log.Message, Date = DateTime.Now });

            await _context.SaveChangesAsync();
        }
    }
}
