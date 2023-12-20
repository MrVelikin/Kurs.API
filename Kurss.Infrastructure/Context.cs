using Kurss.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kurss.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) 
        {

        }
        public DbSet<Person> Persons { get; set; } 
        public DbSet<Documents> Documents { get; set; }
        public DbSet<Pasport> Pasports { get; set; } 
        public DbSet<Administrator> Administrators { get; set; } 

        public DbSet<Sertificate> Sertificats { get; set; }

        public DbSet<PersonalData> PersonalDatas { get; set; }

        public DbSet<Address> Addreses { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 

        }
    }
}