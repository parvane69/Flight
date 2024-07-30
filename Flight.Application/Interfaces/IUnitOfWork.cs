using Flight.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IFlightRepository FlightRepository { get; }
        ISubscriptionRepository SubscriptionRepository { get; }
        Task<int> SaveChangesAsync();
    }
}

