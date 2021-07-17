using Management.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Management.Domain
{
    public class Employee : Person
    {
        public Employee(int id, string name, DateTime birthDate, Gender gender, string cpf, string phoneNumber, string address, bool isActive, ICollection<Dependent> dependents):base(id, name, birthDate, gender)
        {
            if (string.IsNullOrEmpty(cpf))
                throw new ArgumentNullException("Cpf cannot be null or empty");

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

        public string Cpf { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Dependent> Dependents { get; set; }
    }
}
