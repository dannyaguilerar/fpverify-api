namespace VerifyApi.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreatedUtc { get; set; }

        public virtual ICollection<FingerprintRecord> FingerprintRecords { get; set; }
    }
}
