using Infrastructure.Repository.DTO;
using Management.Domain;
using Management.Domain.Interfaces;
using System.Linq;

namespace Infrastructure.Repository.Parse
{
    public class EmployeeParse : IParse<Employee, EmployeeDTO>
    {
        public EmployeeDTO Parse(Employee employee) => new EmployeeDTO
        {
            Name = employee.Name,
            Address = employee.Address,
            BirthDate = employee.BirthDate,
            Cpf = employee.Cpf,
            Gender = employee.Gender.ToString(),
            IsActive = employee.IsActive,
            PhoneNumber = employee.PhoneNumber,
            Dependents = employee.Dependents?.Select(e => new DependentDTO {Gender = e.Gender.ToString(), Name = e.Name, BirthDate = e.BirthDate }).ToList()
        };
    }
}
