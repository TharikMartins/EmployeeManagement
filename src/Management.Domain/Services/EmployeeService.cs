using Management.Domain.Interfaces;
using System;

namespace Management.Domain.Services
{
    public class EmployeeService
    {
        private readonly IRepository<Employee> _repository;
        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public void Insert(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException("Employee cannot be null");

            _repository.Insert(employee);
        }

        public Employee Get(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException("Id cannot be 0 or less than.");

            return _repository.Get(Id);
        }
    }
}
