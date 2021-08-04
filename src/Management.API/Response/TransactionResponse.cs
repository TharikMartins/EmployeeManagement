using Management.Domain;

namespace Management.API.Response
{
    public class TransactionResponse : BaseResponse<ResultTransaction>
    {
        public TransactionResponse(ResultTransaction data) : base(data) { }
    }
}
