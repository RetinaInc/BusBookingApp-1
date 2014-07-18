using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain.Bus;
using MySql.Data.Entity;


namespace Service.Data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BusContext : DbContext
    {
        public BusContext() : base("TriopodeaDb") { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<BusType> BuseTypes { get; set; }
        public DbSet<SeatFormat> SeatFormats { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remove auto pluralization of table names
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //schedule configurations
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

            //set table names
            modelBuilder.Entity<Company>().ToTable("bus_company");
            modelBuilder.Entity<BusType>().ToTable("bus_type");
            modelBuilder.Entity<SeatFormat>().ToTable("bus_seat_format");
            modelBuilder.Entity<Seat>().ToTable("bus_seat");
            modelBuilder.Entity<Location>().ToTable("bus_location");
            modelBuilder.Entity<Schedule>().ToTable("bus_schedule");
            modelBuilder.Entity<Ticket>().ToTable("bus_ticket");
            modelBuilder.Entity<Order>().ToTable("bus_ticket_order");

            // remove one to many cascade convention
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
