
using Flight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Infrastructure.Repositories
{
    public class FlightRepository : Flight.Application.Interfaces.Repositories.IFlightRepository
    {
        private readonly FlightDbContext _context;

        public FlightRepository(FlightDbContext context)
        {
            _context = context;
        }

        public async Task<List<Flights>> GetFlightsAsync(DateTime startDate, DateTime endDate, int agencyId)
        {
            return await _context.Flights
            .Include(f => f.Route)
            .Where(f => f.Departure_Time >= startDate && f.Departure_Time <= endDate)
            .ToListAsync();
        }

        public async Task<List<Flights>> GetAllFlightsAsync()
        {
            return await _context.Flights
            .Include(f => f.Route)
            .ToListAsync();
        }
    }
}



