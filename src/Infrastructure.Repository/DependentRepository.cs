using Infrastructure.Repository.Context;
using Infrastructure.Repository.DTO;
using Management.Domain;
using Management.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class DependentRepository : IRepository<Dependent>
    {
        private readonly EnterpriseContext _context;
        private readonly IParse<Dependent, DependentDTO> _parse;

        public DependentRepository(EnterpriseContext context, IParse<Dependent, DependentDTO> parse)
        {
            _context = context;
            _parse = parse;
        }
        public void Insert(Dependent dependent)
        {
            _context.Dependent.Add(_parse.Parse(dependent));

            _context.SaveChanges();
        }
        public List<Dependent> Get()
        {
            List<DependentDTO> dto = _context.Dependent
                .Include(d => d.Employee)
                .ToList();

            var dependents = new List<Dependent>(dto.Count);
            dto.ForEach(d =>
            {
                dependents.Add(_parse.Parse(d));
            });

            return dependents;
        }

        public Dependent Get(int Id)
        {
            DependentDTO dto = _context.Dependent
                   .Where(d => d.Id == Id)
                   .Include(e => e.Employee)
                   .FirstOrDefault();

            if (dto is null)
                return null;

            return _parse.Parse(dto);
        }

        public bool Delete(int Id)
        {
            DependentDTO dto = _context.Dependent
                   .Where(d => d.Id == Id)
                   .Include(e => e.Employee)
                   .FirstOrDefault();

            if (dto is null)
                return false;

            _context.Dependent.Remove(dto);
            
            _context.SaveChanges();

            return true;

        }

        public bool Update(Dependent dependent, int id)
        {
            DependentDTO dto = _context.Dependent
                .Where(e => e.Id == id)
                .Include(e => e.Employee)
                .FirstOrDefault();

            if (dto is null)
                return false;

            dto.Name = dependent.Name;
            dto.BirthDate = dependent.BirthDate;
            dto.Gender = dependent.Gender.ToString();
            dto.EmployeeId = dependent.EmployeeId;

            _context.Dependent.Update(dto);

            _context.SaveChanges();

            return true;
        }
    }
}
