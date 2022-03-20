namespace VerifyApi.Responses
{
    public class VerifyResponse : BaseApiResponse
    {
        public VerifyResult Result { get; private set; }

        public VerifyResponse(VerifyResult result)
        {
            Result = result;
        }

        public VerifyResponse(VerifyResult result, string message)
        {
            Result = result;
            Message = message;
        }

        public override string ToString()
        {
            return $"Verification resulted in {Result}.";
        }
    }
}