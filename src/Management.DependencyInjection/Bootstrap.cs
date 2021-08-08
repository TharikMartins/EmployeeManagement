using Management.Infrastructure.Repository;
using Management.Infrastructure.Repository.DTO;
using Management.Infrastructure.Repository.Parse;
using Management.Domain;
using Management.Domain.Interfaces;
using Management.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Management.DependencyInjection
{
    public static class Bootstrap
    {
        public static IServiceCollection AddDependency(this IServiceCollection service) =>
            service.AddTransient<IService<Employee>, EmployeeService>()
           .AddTransient<IService<Dependent>, DependentService>()
           .AddTransient<IRepository<Employee>, EmployeeRepository>()
           .AddTransient<IRepository<Dependent>, DependentRepository>()
           .AddTransient<IParse<Employee, EmployeeDTO>, EmployeeParse>()
           .AddTransient<IParse<Dependent, DependentDTO>, DependentParse>();
    }
}
