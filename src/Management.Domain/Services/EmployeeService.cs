using Management.Domain.Interfaces;
using System;
using System.Collections.Generic;

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

        public List<Employee> Get()
        {
            return _repository.Get();
        }

        public Employee Get(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException("Id cannot be 0 or less than.");

            return _repository.Get(Id);
        }

        public bool Delete(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException("Id cannot be 0 or less than.");

           return _repository.Delete(Id);
        }
    }
}
