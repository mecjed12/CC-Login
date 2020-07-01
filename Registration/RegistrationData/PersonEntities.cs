using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationData
{
    public class PersonEntities : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=personadmin;user=root");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(e => e.HasKey(x => x.Id));
            modelBuilder.Entity<Address>(e => e.HasKey(x => x.Id));

            modelBuilder.Entity<PersonAddress>().HasOne(pa => pa.Person).WithOne(p => p.PAddress).HasForeignKey<PersonAddress>(pa => pa.PersonId);
            modelBuilder.Entity<PersonAddress>().HasOne(pa => pa.Address).WithOne(a => a.PAddress).HasForeignKey<PersonAddress>(pa => pa.AddressId);

        }

    }
}
