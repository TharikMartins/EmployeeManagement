namespace Management.API.Response
{
    public class TransactionResponse
    {
        public TransactionResponse(bool success)
        {
            Success = success;
        }

        public bool Success { get; set; }
    }
}
