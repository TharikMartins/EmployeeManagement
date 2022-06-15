using Management.Infrastructure.Repository.Context;
using Management.Infrastructure.Repository.DTO;
using Management.Domain;
using Management.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.Infrastructure.Repository
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

        public async Task Insert(Dependent dependent)
        {
            await _context.Dependent.AddAsync(_parse.Parse(dependent));

            await _context.SaveChangesAsync();
        }

        public async Task<List<Dependent>> Get()
        {
            List<DependentDTO> dto = await _context.Dependent
                .Include(d => d.Employee)
                .ToListAsync();

            var dependents = new List<Dependent>(dto.Count);
            dto.ForEach(d =>
            {
                dependents.Add(_parse.Parse(d));
            });

            return await Task.FromResult(dependents);
        }

        public async Task<Dependent> Get(int Id)
        {
            DependentDTO dto = await _context.Dependent
                   .Where(d => d.Id == Id)
                   .Include(e => e.Employee)
                   .FirstOrDefaultAsync();

            if (dto is null)
                return null;


            return await Task.FromResult(_parse.Parse(dto));
        }

        public async Task<bool> Delete(int Id)
        {
            DependentDTO dto = await _context.Dependent
                   .Where(d => d.Id == Id)
                   .Include(e => e.Employee)
                   .FirstOrDefaultAsync();

            if (dto is null)
                return await Task.FromResult(false); ;

            _context.Dependent.Remove(dto);

           await _context.SaveChangesAsync();

            return await Task.FromResult(true); ;

        }

        public async Task<bool> Update(Dependent dependent, int id)
        {
            DependentDTO dto = await _context.Dependent
                .Where(e => e.Id == id)
                .Include(e => e.Employee)
                .FirstOrDefaultAsync();

            if (dto is null)
                return await Task.FromResult(false);

            dto.Name = dependent.Name;
            dto.BirthDate = dependent.BirthDate;
            dto.Gender = dependent.Gender.ToString();
            dto.EmployeeId = dependent.EmployeeId;

            _context.Dependent.Update(dto);

            _context.SaveChanges();

            return await Task.FromResult(true); ;
        }
    }
}
