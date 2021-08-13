using Management.Domain.Enum;
using System;

namespace Management.Domain
{
    public abstract class Person
    {
        protected Person(int? id , string name, DateTime birthDate, Gender gender)
        {

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be null or empty.");

            if(id != null && id <= 0)
                throw new ArgumentException("Id cannot be 0 or less than.");

            Id = id;
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
        }
        
        public int? Id { get; }
        public string Name { get; }
        public DateTime BirthDate { get; }
        public Gender Gender { get; }
    }
}
