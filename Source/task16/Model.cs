using MySql.Data;
using System.Data.Common;
using System.Data.Entity;

namespace EF6
{
    // Code-Based Configuration and Dependency resolution
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Parking : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public Parking() : base()
        {

        }

        // Constructor to use on a DbConnection that is already opened
        public Parking(DbConnection existingConnection, bool contextOwnsConnection): base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>().MapToStoredProcedures();
        }
    }

    public class Car
    {
        public int CarId { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string Manufacturer { get; set; }
    }
}