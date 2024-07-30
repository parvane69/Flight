using Flight.Application.Interfaces;
using Flight.Application.Interfaces.Repositories;
using Flight.Infrastructure.Repositories;

namespace Flight.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlightDbContext _context;
        private IFlightRepository _flightRepository;
        private IRouteRepository _routeRepository;
        private ISubscriptionRepository _subscriptionRepository;

        public UnitOfWork(FlightDbContext context)
        {
            _context = context;
        }

        public IFlightRepository FlightRepository
        {
            get
            {
                return _flightRepository ??= new FlightRepository(_context);
            }
        }

        public IRouteRepository RouteRepository
        {
            get
            {
                return _routeRepository ??= new RouteRepository(_context);
            }
        }

        public ISubscriptionRepository SubscriptionRepository
        {
            get
            {
                return _subscriptionRepository ??= new SubscriptionRepository(_context);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }

}




