using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain.Bus;
using MySql.Data.Entity;


namespace Service.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BusContext : DbContext
    {
        public BusContext() : base("TriopodeaBus") { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<BusType> BuseTypes { get; set; }
        //public DbSet<Seat_old> Seats { get; set; }
        public DbSet<SeatFormat> SeatFormats { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remove auto pluralization of table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //schedule configurations
            modelBuilder.Entity<Schedule>()
                .HasRequired(s => s.JourneyFrom)
                    .WithMany(l => l.FromSchedules)
                    .HasForeignKey(s => s.JourneyFromId)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Schedule>()
                .HasRequired(s => s.JourneyTo)
                    .WithMany(l => l.ToSchedules)
                    .HasForeignKey(s => s.JourneyToId)
                    .WillCascadeOnDelete(false);

            // remove one to many cascade convention
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
