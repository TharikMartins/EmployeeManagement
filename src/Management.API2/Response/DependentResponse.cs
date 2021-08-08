using Management.Domain;

namespace Management.API.Response
{
    public class DependentResponse : BaseResponse<Dependent>
    {
        public DependentResponse(Dependent data) : base(data) {}
    }
}
