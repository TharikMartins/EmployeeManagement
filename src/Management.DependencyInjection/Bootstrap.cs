using Infrastructure.Repository;
using Infrastructure.Repository.DTO;
using Infrastructure.Repository.Parse;
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
            service.AddTransient<EmployeeService>()
           .AddTransient<IRepository<Employee>, EmployeeRepository>()
           .AddTransient<IParse<Employee, EmployeeDTO>, EmployeeParse>();
    }
}
