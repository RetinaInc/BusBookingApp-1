using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain.Bus;
using Domain.Common;


namespace Service.Data
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("TripodeaDb") { }

        // bus entities start
        public DbSet<Company> Companies { get; set; }
        public DbSet<BusType> BuseTypes { get; set; }
        public DbSet<SeatFormat> SeatFormats { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        // bus entities end

        // common entities start
        public DbSet<Order> Orders { get; set; }
        // common entities end

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //bus schedule configurations
            //journeyFrom foreign key
            modelBuilder.Entity<Schedule>()
                .HasRequired(s => s.JourneyFrom)
                    .WithMany(l => l.FromSchedules)
                    .HasForeignKey(s => s.JourneyFromId)
                    .WillCascadeOnDelete(false);
            //journeyTo foreign key
            modelBuilder.Entity<Schedule>()
                .HasRequired(s => s.JourneyTo)
                    .WithMany(l => l.ToSchedules)
                    .HasForeignKey(s => s.JourneyToId)
                    .WillCascadeOnDelete(false);

            // set table names
            // table name for bus module
            modelBuilder.Entity<Company>().ToTable("bus_company");
            modelBuilder.Entity<BusType>().ToTable("bus_type");
            modelBuilder.Entity<SeatFormat>().ToTable("bus_seat_format");
            modelBuilder.Entity<Seat>().ToTable("bus_seat");
            modelBuilder.Entity<Location>().ToTable("bus_location");
            modelBuilder.Entity<Schedule>().ToTable("bus_schedule");
            modelBuilder.Entity<Ticket>().ToTable("bus_ticket");
            
            // table names for common
            modelBuilder.Entity<Order>().ToTable("order");
            
            // remove one to many cascade convention
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
