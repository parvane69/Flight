using Flight.Domain.Entities;
using Flight.Infrastructure.Persistence.Config;
using Microsoft.EntityFrameworkCore;
using Portal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Infrastructure
{
    public class FlightDbContext : DbContext
    {
        public FlightDbContext(DbContextOptions<FlightDbContext> options)
              : base(options)
        {
        }

        public FlightDbContext()
        {
        }

        public DbSet<Routes> Routes { get; set; }
        public DbSet<Flights> Flights { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FlightsConfig());
            builder.ApplyConfiguration(new RoutesConfig());

            base.OnModelCreating(builder);
        }

    }
}
