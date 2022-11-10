namespace VerifyApi.Services
{
    public class MatcherService : IMatcherService
    {
        
        public VerifyResponse Verify(VerifyRequest request)
        {
            if (request.ProbeBase64 == null)
            {
                return new VerifyResponse(VerifyResult.NoMatch, 0, "Invalid probe image");
            }

            if (request.CandidateBase64 == null)
            {
                return new VerifyResponse(VerifyResult.NoMatch, 0, "Invalid candidate image");
            }
            try
            {   
                var probeData = Convert.FromBase64String(request.ProbeBase64);
                var probeImage = new FingerprintImage(probeData);
                var probeTemplate = new FingerprintTemplate(probeImage);

                var candidateData = Convert.FromBase64String(request.CandidateBase64);
                var candidateImage = new FingerprintImage(candidateData);
                var candidateTemplate = new FingerprintTemplate(candidateImage);

                var matcher = new FingerprintMatcher(probeTemplate);
                double score = matcher.Match(candidateTemplate);
                
                matcher = null;
                probeImage = null;
                probeTemplate = null;
                probeData = null;
                candidateData = null;
                candidateTemplate = null;
                candidateImage = null;

                double threshold = 40;
                bool matches = score >= threshold;

                if(score >= threshold)
                {
                    return new VerifyResponse(VerifyResult.Match, (int)score, "MATCH");
                }
                else
                {
                    return new VerifyResponse(VerifyResult.NoMatch, (int) score, "NOT MATCH");
                }
            }
            catch (Exception ex)
            {
                return new VerifyResponse(VerifyResult.Undefined, 0, $"Error: {ex.Message}");
            }
        }
    }
}