using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Infrastructure.Repositories
{
    public class RouteRepository : Flight.Application.Interfaces.Repositories.IRouteRepository
    {
        private readonly FlightDbContext _context;

        public RouteRepository(FlightDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddRoutes(List<Domain.Entities.Routes> items)
        {
            await _context.Routes.AddRangeAsync(items);
            return 1;
        }
    }
}
