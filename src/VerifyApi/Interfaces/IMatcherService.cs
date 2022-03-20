namespace VerifyApi.Interfaces
{
    public interface IMatcherService
    {
        VerifyResponse Verify(VerifyRequest request);
    }
}