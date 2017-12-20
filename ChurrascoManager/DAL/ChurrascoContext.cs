using ChurrascoManager.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ChurrascoManager.DAL
{
    public class ChurrascoContext : DbContext
    {
        public ChurrascoContext() : base("ChurrascoContext") { }

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}