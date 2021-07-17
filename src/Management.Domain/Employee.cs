using System;

namespace Management.Domain
{
    public class Employee
    {

        public Employee(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Name cannot be null or empty.");

            Name = name;
        }
        public string Name { get; set; }
    }
}
