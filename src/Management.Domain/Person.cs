using Management.Domain.Enum;
using System;

namespace Management.Domain
{
    public abstract class Person
    {
        protected Person(string name, DateTime birthDate, Gender gender)
        {

            if (string.IsNullOrEmpty(name))
                throw new Exception("Name cannot be null or empty");

            Name = name;
            BirthDate = birthDate;
            Gender = gender;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
    }
}
