using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.Entity;
using MySql.Data.Entity;

namespace Model
{
    [DbConfigurationType(typeof (MySqlEFConfiguration))]
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().MapToStoredProcedures();
            modelBuilder.Entity<Person>().HasKey(person => person.Id);
            modelBuilder.Entity<Person>().Property(person => person.Name).HasColumnName("Name");
            modelBuilder.Entity<Person>().Property(person => person.SurName).HasColumnName("SurName");
            modelBuilder.Entity<Person>().Property(person => person.Email).HasColumnName("Email");
            modelBuilder.Entity<Person>().Property(person => person.Patronymic).HasColumnName("Patronymic");
            modelBuilder.Entity<Person>().Property(person => person.Organization).HasColumnName("Organization");
            modelBuilder.Entity<Person>().Property(person => person.NumberPhone).HasColumnName("NumberPhone");
            modelBuilder.Entity<Person>().Property(person => person.Position).HasColumnName("Position");
        }
    }
}