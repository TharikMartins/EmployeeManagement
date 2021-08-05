using Infrastructure.Repository.DTO;
using Management.Domain;
using Management.Domain.Interfaces;
using System;
using DomainEnum = Management.Domain.Enum;

namespace Infrastructure.Repository.Parse
{
    public class DependentParse : IParse<Dependent, DependentDTO>
    {
        public DependentDTO Parse(Dependent dependent) => new DependentDTO
        {
            Name = dependent.Name,
            EmployeeId = dependent.EmployeeId,
            BirthDate = dependent.BirthDate,
            Gender = dependent.Gender.ToString(),
        };

        public Dependent Parse(DependentDTO obj) => new Dependent(obj.Id, obj.Name, obj.BirthDate,
            (DomainEnum.Gender)(Enum.Parse(typeof(DomainEnum.Gender), obj.Gender)), obj.EmployeeId);
    }
}
