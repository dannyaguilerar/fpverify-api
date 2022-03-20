namespace VerifyApi.Requests
{
    public class VerifyRequest 
    {
        public string? ProbeBase64 { get; set; }

        public string? CandidateBase64 { get; set; }
    }
}