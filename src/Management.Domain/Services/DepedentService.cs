using Management.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Domain.Services
{
    public class DependentService : IService<Dependent>
    {
        private readonly IRepository<Dependent> _repository;

        public DependentService(IRepository<Dependent> repository)
        {
            _repository = repository;
        }

        public async Task Insert(Dependent dependent)
        {
            if (dependent is null)
                throw new ArgumentNullException("Dependent cannot be null");

           await _repository.Insert(dependent);
        }

        public async Task<List<Dependent>> Get()
        {
            return await _repository.Get();
        }

        public async Task<Dependent> Get(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id cannot be 0 or less than.");

            return await _repository.Get(id);
        }

        public async Task<bool> Update(Dependent dependent, int id)
        {
            if (dependent is null) throw new ArgumentNullException("Employee cannot be null");
            if (id <= 0) throw new ArgumentException("Id cannot be 0 or less than.");

            return await _repository.Update(dependent, id);

        }

        public async Task<bool> Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Id cannot be 0 or less than.");

            return await _repository.Delete(id);
        }
    }
}
