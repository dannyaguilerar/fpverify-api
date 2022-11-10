using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerifyApi.Entities;

namespace VerifyApi.Data
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.PersonId);
            builder.Property(p => p.PersonId).UseIdentityAlwaysColumn();
        }
    }
}
