using Flight.Application.Subscriptions.Dto;
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
        public async Task<int> AddSubscriptions(List<Domain.Entities.Subscriptions> items)
        {
            await _context.Subscriptions.AddRangeAsync(items);
            return 1;
        }
    }
}
