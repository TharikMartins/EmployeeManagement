using Management.Infrastructure.Repository.Context;
using Management.Infrastructure.Repository.DTO;
using Management.Domain;
using Management.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.Infrastructure.Repository
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

        public async Task Insert(Employee employee)
        {
            await _context.Employee.AddAsync(_parse.Parse(employee));

            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> Get()
        {
            List<EmployeeDTO> dto = await _context.Employee
                .Include(e => e.Dependents)
                .ToListAsync();

            var employees = new List<Employee>(dto.Count);
            dto.ForEach(d =>
            {
                employees.Add(_parse.Parse(d));
            });

            return employees;
        }

        public async Task<Employee> Get(int Id)
        {
            EmployeeDTO dto = await _context.Employee
                .Where(e => e.Id == Id)
                .Include(e => e.Dependents)
                .FirstOrDefaultAsync();

            if (dto is null)
                return null;

            return _parse.Parse(dto);
        }
        public async Task<bool> Update(Employee employee, int Id)
        {
            EmployeeDTO dto = _context.Employee
                .Where(e => e.Id == Id)
                .Include(e => e.Dependents)
                .FirstOrDefault();

            if (dto is null)
                return await Task.FromResult(false);

            dto.Name = employee.Name;
            dto.Cpf = employee.Cpf;
            dto.Address = employee.Address;
            dto.BirthDate = employee.BirthDate;
            dto.Gender = employee.Gender.ToString();
            dto.PhoneNumber = employee.PhoneNumber;
            dto.IsActive = employee.IsActive;

            _context.Employee.Update(dto);

           await _context.SaveChangesAsync();

            return await Task.FromResult(true);
        }
        public async Task<bool> Delete(int Id)
        {
            EmployeeDTO dto = await _context.Employee
                .Where(e => e.Id == Id)
                .Include(e => e.Dependents)
                .FirstOrDefaultAsync();

            if (dto is null)
                return await Task.FromResult(false); 

            _context.Employee.Remove(dto);

            await _context.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
