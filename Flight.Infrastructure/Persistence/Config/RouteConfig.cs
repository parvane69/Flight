using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flight.Domain.Entities;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Emit;

namespace Flight.Infrastructure.Persistence.Config
{
    public class RoutesConfig : IEntityTypeConfiguration<Routes>
    {
        public void Configure(EntityTypeBuilder<Routes> builder)
        {
            builder.Property(x => x.Departure_Date)
                     .HasConversion<DateOnlyConverter, DateOnlyComparer>();
            builder.HasIndex(e => new { e.Departure_City_Id, e.Origin_City_Id, e.Departure_Date })
            .IsUnique();
            builder
            .Property(r => r.Id)
            .ValueGeneratedNever();
        }
    }
}
public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter() : base(
            d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.FromDateTime(d))
    { }
}
public class DateOnlyComparer : ValueComparer<DateOnly>
{
    public DateOnlyComparer() : base(
        (d1, d2) => d1.DayNumber == d2.DayNumber,
        d => d.GetHashCode())
    {
    }
}
