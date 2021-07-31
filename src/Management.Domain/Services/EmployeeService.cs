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
            _repository.Insert(employee);
        }
    }
}
