namespace Management.API.Response
{
    public abstract class BaseResponse<T> where T : class
    {
        public T Data { get; }
        public string Message { get; }
        public BaseResponse(T data, string message = "")
        {
            Data = data;
            Message = message;
        }
    }
}
