﻿using Infrastructure.Repository.Context;
using Infrastructure.Repository.DTO;
using Management.Domain;
using Management.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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
    }
}
