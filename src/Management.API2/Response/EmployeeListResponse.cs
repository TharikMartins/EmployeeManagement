using Management.Domain;
using System.Collections.Generic;

namespace Management.API.Response
{
    public class DependentListResponse : BaseResponse<IEnumerable<Dependent>>
    {
        public DependentListResponse(IEnumerable<Dependent> data) : base(data) {}
    }
}
