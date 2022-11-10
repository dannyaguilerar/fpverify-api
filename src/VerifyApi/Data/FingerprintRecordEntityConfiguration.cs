using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerifyApi.Entities;

namespace VerifyApi.Data
{
    public class FingerprintRecordEntityConfiguration : IEntityTypeConfiguration<FingerprintRecord>
    {
        public void Configure(EntityTypeBuilder<FingerprintRecord> builder)
        {
            builder.HasKey(fr => fr.FingerprintRecordId);
            builder.Property(fr => fr.FingerprintRecordId).UseIdentityAlwaysColumn();
            builder.HasOne(fr => fr.Person)
                .WithMany(p => p.FingerprintRecords)
                .HasForeignKey(fr => fr.PersonId);
        }
    }
}
