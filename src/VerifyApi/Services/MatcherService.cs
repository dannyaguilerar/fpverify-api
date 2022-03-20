namespace VerifyApi.Services
{
    public class MatcherService : IMatcherService
    {
        
        public VerifyResponse Verify(VerifyRequest request)
        {
            if (request.ProbeBase64 == null)
            {
                return new VerifyResponse(VerifyResult.NoMatch, "Invalid probe image");
            }

            if (request.CandidateBase64 == null)
            {
                return new VerifyResponse(VerifyResult.NoMatch, "Invalid candidate image");
            }
            try
            {
                var options = new FingerprintImageOptions { Dpi = 500 };
                
                var probeData = Convert.FromBase64String(request.ProbeBase64);
                var probeImage = Image.Load(probeData);
                var probeTemplate = new FingerprintTemplate(new FingerprintImage(probeImage.Width, probeImage.Height, probeData, options));

                var candidateData = Convert.FromBase64String(request.CandidateBase64);
                var candidateImage = Image.Load(candidateData);
                var candidateTemplate = new FingerprintTemplate(new FingerprintImage(candidateImage.Width, candidateImage.Height, candidateData, options));

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
                    return new VerifyResponse(VerifyResult.Match);
                }
                else
                {
                    return new VerifyResponse(VerifyResult.NoMatch);
                }
            }
            catch (Exception ex)
            {
                return new VerifyResponse(VerifyResult.Undefined, $"Error: {ex.Message}");
            }
        }
    }
}