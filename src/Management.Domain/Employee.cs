using Management.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Management.Domain
{
    public class Employee : Person
    {
        public Employee(int? id, string name, DateTime birthDate, Gender gender, string cpf, string phoneNumber, string address, bool isActive,
            IEnumerable<Dependent> dependents) : base(id, name, birthDate, gender)
        {
            if (string.IsNullOrEmpty(cpf) || cpf.Length != 11)
                throw new ArgumentException("Cpf cannot be null or empty and cannot be more or less that 11 characters");

            if (string.IsNullOrEmpty(phoneNumber))
                throw new ArgumentNullException("PhoneNumber cannot be null or empty");

            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException("Address cannot be null or empty");

            Cpf = cpf;
            PhoneNumber = phoneNumber;
            Address = address;
            IsActive = isActive;
            Dependents = dependents;
        }

        public string Cpf { get; }
        public string PhoneNumber { get; }
        public string Address { get; }
        public bool IsActive { get; }
        public IEnumerable<Dependent> Dependents { get; }
    }
}
