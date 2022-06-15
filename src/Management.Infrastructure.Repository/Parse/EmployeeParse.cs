using Management.Infrastructure.Repository.DTO;
using Management.Domain;
using Management.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using EnumDomain = Management.Domain.Enum;

namespace Management.Infrastructure.Repository.Parse
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
            Dependents = employee.Dependents?.Select(e => new DependentDTO { Gender = e.Gender.ToString(), Name = e.Name, BirthDate = e.BirthDate }).ToList()
        };

        public Employee Parse(EmployeeDTO dto) => new Employee(dto.Id, dto.Name, dto.BirthDate, (EnumDomain.Gender)Enum.Parse(typeof(EnumDomain.Gender), dto.Gender),
            dto.Cpf, dto.PhoneNumber, dto.Address, dto.IsActive, this.parseDependents(dto.Dependents));

        private IEnumerable<Dependent> parseDependents(ICollection<DependentDTO> dependentsDto)
        {
            return dependentsDto.Select(dto => new Dependent(dto.Id, dto.Name, dto.BirthDate,
                     (EnumDomain.Gender)Enum.Parse(typeof(EnumDomain.Gender), dto.Gender), dto.EmployeeId));
        }
    }
}
