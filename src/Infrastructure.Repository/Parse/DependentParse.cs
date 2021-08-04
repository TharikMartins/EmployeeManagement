using Infrastructure.Repository.DTO;
using Management.Domain;
using Management.Domain.Interfaces;

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
    }
}
