﻿using Management.Domain.Enum;
using System;

namespace Management.Domain
{
    public class Dependent : Person
    {

        public Dependent(string name, DateTime birthDate, Gender gender, Employee employee) : base(name, birthDate, gender)
        {
            if (employee == null)
                throw new ArgumentNullException("Employee cannot be null.");

            Employee = employee;

            EmployeeId = employee.Id;
        }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
