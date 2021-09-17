namespace Management.Domain
{
    public class Log
    {
        public Log(string methodType, string endpointName, string message)
        {
            MethodType = methodType;
            EndpointName = endpointName;
            Message = message;
        }

        public string MethodType { get; set; }
        public string EndpointName { get; }
        public string Message { get; }
    }
}
