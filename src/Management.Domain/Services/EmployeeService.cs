using Management.Domain.Interfaces;
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
                throw new System.ArgumentNullException("Employee cannot be null");

            _repository.Insert(employee);
        }
    }
}
