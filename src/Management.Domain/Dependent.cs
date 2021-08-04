using Management.Domain.Enum;
using System;

namespace Management.Domain
{
    public class Dependent : Person
    {

        public Dependent(string name, DateTime birthDate, Gender gender, int employeeId) : base(name, birthDate, gender)
        {
            EmployeeId = employeeId;
        }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
