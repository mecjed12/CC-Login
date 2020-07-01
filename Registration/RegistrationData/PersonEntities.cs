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
        public DbSet<MasterFile> Masters { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=personadmin;user=root");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MasterFile>(e => e.HasKey(x => x.Id));


            modelBuilder.Entity<Address>(e => e.HasKey(x => x.Id));



            modelBuilder.Entity<Address>().HasOne(a => a.Master).WithOne(m => m.Address);

        }

    }
}
