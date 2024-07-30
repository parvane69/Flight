using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Flight.Infrastructure.Persistence.Config
{
    public class FlightsConfig : IEntityTypeConfiguration<Flights>
    {
        public void Configure(EntityTypeBuilder<Flights> builder)
        {
            //builder.HasIndex(c => c.Name).IsUnique();
            //builder.Property(c => c.Name).HasMaxLength(25).IsRequired();
            //builder.Property(c => c.Description).HasMaxLength(1000).IsRequired();
            //builder.OwnsOne(f => f.Price);
        }
    }
    
}
