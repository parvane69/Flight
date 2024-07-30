using Flight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flight.Infrastructure.Repositories
{
    public class SubscriptionRepository : Flight.Application.Interfaces.Repositories.ISubscriptionRepository
    {
        private readonly FlightDbContext _context;

        public SubscriptionRepository(FlightDbContext context)
        {
            _context = context;
        }

        public async Task<List<Subscriptions>> GetSubscriptionsAsync(int agencyId)
        {
            return await _context.Subscriptions
            .Where(s => s.Agency_Id == agencyId)
            .ToListAsync();
        }
    }
}
