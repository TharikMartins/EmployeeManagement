using Management.Domain.Interfaces;
using System;
using System.Collections.Generic;

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

        public List<Dependent> Get()
        {
            return _repository.Get();
        }

        public Dependent Get(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id cannot be 0 or less than.");

            return _repository.Get(id);
        }

        public bool Update(Dependent dependent, int id)
        {
            if (dependent is null) throw new ArgumentNullException("Employee cannot be null");
            if (id <= 0) throw new ArgumentException("Id cannot be 0 or less than.");

            return _repository.Update(dependent, id);

        }

        public bool Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id cannot be 0 or less than.");

            return _repository.Delete(id);
        }
    }
}
