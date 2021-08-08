using Management.Domain;
using System.Collections.Generic;

namespace Management.API.Response
{
    public class EmployeeListResponse : BaseResponse<IEnumerable<Employee>>
    {
        public EmployeeListResponse(IEnumerable<Employee> data) : base(data) {}
    }
}
