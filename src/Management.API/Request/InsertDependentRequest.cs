using System;

namespace Management.API.Request
{
    public class InsertDependentRequest
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
        public int EmployeeId { get; set; }
    }
}
