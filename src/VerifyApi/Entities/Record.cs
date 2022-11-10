namespace VerifyApi.Entities
{
    public class FingerprintRecord
    {
        public int FingerprintRecordId { get; set; }
        public int PersonId { get; set; }
        public string RightIndex { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }

        public virtual Person Person { get; set; }
    }
}
