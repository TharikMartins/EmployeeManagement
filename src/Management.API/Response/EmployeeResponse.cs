using Management.Domain;

namespace Management.API.Response
{
    public class EmployeeResponse : BaseResponse<Employee>
    {
        public EmployeeResponse(Employee data) : base(data) {}
    }
}
