using Microsoft.EntityFrameworkCore;
using RegistrationData.model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationData
{
    public class DcvEntities : DbContext
    {
        public DbSet<Person> People { get; set; }

        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=192.168.0.94;database=dcv;user=root;convert zero datetime=true");
            //optionsBuilder.UseMySQL("server=localhost;database=dcv;user=root;convert zero datetime=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(e => e.HasKey(x => x.Id));

            modelBuilder.Entity<Person>(e => e.HasKey(x => x.Id));
            modelBuilder.Entity<Address>(e => e.HasKey(x => x.Id));
            modelBuilder.Entity<PersonAddress>(e => e.HasKey(x => x.Id));
            
            modelBuilder.Entity<Person>(e => e.HasMany(x => x.PAddress).WithOne());
            modelBuilder.Entity<Address>(e => e.HasMany(x => x.PAddress).WithOne());

            modelBuilder.Entity<PersonAddress>().HasOne(pa => pa.Person).WithMany(p => p.PAddress).HasForeignKey(pa => pa.PersonId);
            modelBuilder.Entity<PersonAddress>().HasOne(pa => pa.Address).WithMany(a => a.PAddress).HasForeignKey(pa => pa.AddressId);
        }
    }
}
