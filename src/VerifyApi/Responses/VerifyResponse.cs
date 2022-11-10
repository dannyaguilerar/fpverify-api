namespace VerifyApi.Responses
{
    public class VerifyResponse : BaseApiResponse
    {
        public VerifyResult Result { get; private set; }
        public int Score { get; private set; }

        public VerifyResponse(VerifyResult result)
        {
            Result = result;
        }

        public VerifyResponse(VerifyResult result, int score, string message)
        {
            Result = result;
            Score = score;
            Message = message;
        }



        public override string ToString()
        {
            return $"Verification resulted in {Result}.";
        }
    }
}