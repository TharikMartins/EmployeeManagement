﻿using Infrastructure.Repository.DTO;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Context
{
    public class EnterpriseContext : DbContext
    {
        public EnterpriseContext(DbContextOptions<EnterpriseContext> options) : base(options)
        {
        }

        public DbSet<EmployeeDTO> Employee { get; set; }
        public DbSet<DependentDTO> Dependent { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EmployeeDTO>()
               .HasMany(e => e.Dependents)
               .WithOne(e => e.Employee)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade)
            .HasPrincipalKey(c => c.Id);
        }
    }
}
