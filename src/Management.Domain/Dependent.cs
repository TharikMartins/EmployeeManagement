using Management.Domain.Enum;
using System;

namespace Management.Domain
{
    public class Dependent : Person
    {

        public Dependent(int? id, string name, DateTime birthDate, Gender gender, int employeeId) 
            : base(id, name, birthDate, gender)
        {
            EmployeeId = employeeId;
        }

        public int EmployeeId { get; }
        public Employee Employee { get; }
    }
}
