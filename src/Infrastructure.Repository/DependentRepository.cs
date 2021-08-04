using Infrastructure.Repository.Context;
using Infrastructure.Repository.DTO;
using Management.Domain;
using Management.Domain.Interfaces;

namespace Infrastructure.Repository
{
    public class DependentRepository : IRepository<Dependent>
    {
        private readonly EnterpriseContext _context;
        private readonly IParse<Dependent, DependentDTO> _parse;

        public DependentRepository(EnterpriseContext context, IParse<Dependent, DependentDTO> parse)
        {
            _context = context;
            _parse = parse;
        }

        public void Insert(Dependent dependent)
        {
            _context.Dependent.Add(_parse.Parse(dependent));
            _context.SaveChanges();
        }
    }
}
