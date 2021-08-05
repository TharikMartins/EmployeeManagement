using Infrastructure.Repository.Context;
using Infrastructure.Repository.DTO;
using Management.Domain;
using Management.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public void Insert(Employee employee)
        {
            _context.Employee.Add(_parse.Parse(employee));

            _context.SaveChanges();
        }

        public List<Employee> Get()
        {
            List<EmployeeDTO> dto = _context.Employee
                .Include(e => e.Dependents)
                .ToList();

            var employees = new List<Employee>(dto.Count);
            dto.ForEach(d =>
            {
                employees.Add(_parse.Parse(d));
            });

            return employees;
        }

        public Employee Get(int Id)
        {
            EmployeeDTO dto = _context.Employee
                .Where(e => e.Id == Id)
                .Include(e => e.Dependents)
                .FirstOrDefault();

            if (dto is null)
                return null;

            return _parse.Parse(dto);
        }
        public bool Update(Employee employee, int Id)
        {
            EmployeeDTO dto = _context.Employee
                .Where(e => e.Id == Id)
                .Include(e => e.Dependents)
                .FirstOrDefault();

            if (dto is null)
                return false;

            dto.Name = employee.Name;
            dto.Cpf = employee.Cpf;
            dto.Address = employee.Address;
            dto.BirthDate = employee.BirthDate;
            dto.Gender = employee.Gender.ToString();
            dto.PhoneNumber = employee.PhoneNumber;
            dto.IsActive = employee.IsActive;

            _context.Employee.Update(dto);
            
            _context.SaveChanges();
            
            return true;
        }
        public bool Delete(int Id)
        {
            EmployeeDTO dto = _context.Employee
                .Where(e => e.Id == Id)
                .Include(e => e.Dependents)
                .FirstOrDefault();

            if (dto is null)
                return false;

            _context.Employee.Remove(dto);

            _context.SaveChanges();

            return true;
        }
    }
}
