using Management.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Repository
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>().ToTable("Employee");
        }
    }
}
