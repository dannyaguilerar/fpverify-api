using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VerifyApi.Entities;

namespace VerifyApi.Data
{
    public class VerifyApiDbContext : DbContext
    {
        DbSet<Person> People { get; set; }
        DbSet<FingerprintRecord> FingerprintRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;database=verifydb;user id=postgres;password=Honduras22;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
