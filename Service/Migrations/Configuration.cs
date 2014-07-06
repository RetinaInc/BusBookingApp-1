using Service.Data;

namespace Service.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Service.Data.BusContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Service.Data.BusContext context)
        {
            InitializeDb.InitializeBus(context);
        }
    }
}
