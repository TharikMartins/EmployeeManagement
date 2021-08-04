namespace Management.API.Response
{
    public class ErrorResponse : BaseResponse<string>
    {
        public ErrorResponse(string data , string message) : base(data, message) { }
    }
}
