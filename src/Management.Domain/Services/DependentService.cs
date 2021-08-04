using Management.Domain.Interfaces;
using System;

namespace Management.Domain.Services
{
    public class DependentService
    {
        private readonly IRepository<Dependent> _repository;

        public DependentService(IRepository<Dependent> repository)
        {
            _repository = repository;
        }
        public void Insert(Dependent dependent)
        {
            if (dependent is null)
                throw new ArgumentNullException("Dependent cannot be null");

            _repository.Insert(dependent);
        }
    }
}
