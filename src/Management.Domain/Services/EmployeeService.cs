using Management.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Domain.Services
{
    public class EmployeeService : IService<Employee>
    {
        private readonly IRepository<Employee> _repository;
        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task Insert(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException("Employee cannot be null");

           await _repository.Insert(employee);
        }

        public async Task<List<Employee>> Get()
        {
            return await _repository.Get();
        }

        public async Task<Employee> Get(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id cannot be 0 or less than.");

            return await _repository.Get(id);
        }

        public async Task<bool> Update(Employee employee, int id)
        {
            if (employee is null) throw new ArgumentNullException("Employee cannot be null");
            if (id <= 0) throw new ArgumentException("Id cannot be 0 or less than.");

            return await _repository.Update(employee, id);

        }

        public async Task<bool> Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id cannot be 0 or less than.");

           return await _repository.Delete(id);
        }
    }
}
