using Infrastructure.Repository.DTO;
using Management.Domain;
using Management.Domain.Interfaces;

namespace Infrastructure.Repository.Parse
{
    public class EmployeeParse : IParse<Employee, EmployeeDTO>
    {
        public EmployeeDTO Parse(Employee employee)
        {
            return new EmployeeDTO();
        }
    }
}
