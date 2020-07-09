using Microsoft.EntityFrameworkCore;
using ApplicationData.model;

namespace ApplicationData
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
            modelBuilder.Entity<Course>().HasKey(x => x.Id);

            modelBuilder.Entity<Person>().HasKey(x => x.Id);
            modelBuilder.Entity<Address>().HasKey(x => x.Id);
            modelBuilder.Entity<RelPersonAddress>().HasKey(x => x.Id);
            modelBuilder.Entity<Contact>().HasKey(x => x.Id);
            
            modelBuilder.Entity<Person>().HasMany(x => x.PAddress).WithOne();
            modelBuilder.Entity<Address>().HasMany(x => x.PAddress).WithOne();

            modelBuilder.Entity<RelPersonAddress>().HasOne(pa => pa.Person).WithMany(p => p.PAddress).HasForeignKey(pa => pa.PersonId);
            modelBuilder.Entity<RelPersonAddress>().HasOne(pa => pa.Address).WithMany(a => a.PAddress).HasForeignKey(pa => pa.AddressId);

            modelBuilder.Entity<Person>().HasMany(x => x.Contacts).WithOne();
            modelBuilder.Entity<Contact>().HasOne(c => c.Person).WithMany(p => p.Contacts).HasForeignKey(c => c.PersonId);
        }
    }
}
