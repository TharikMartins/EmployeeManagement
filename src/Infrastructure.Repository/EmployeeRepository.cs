using Infrastructure.Repository.Context;
using Infrastructure.Repository.DTO;
using Management.Domain;
using Management.Domain.Interfaces;

namespace Infrastructure.Repository
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly EnterpriseContext _context;
        private readonly IParse<Employee, EmployeeDTO> _parse;

        public EmployeeRepository(EnterpriseContext context, IParse<Employee, EmployeeDTO> parse)
        {
            _context = context;
            _parse = parse;
        }

        public void Adicionar(Employee employee)
        {
            _context.Employee.Add(_parse.Parse(employee));
            _context.SaveChanges();
        }
    }
}
