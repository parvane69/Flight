using System.Collections.Generic;
using System.Threading.Tasks;


namespace Flight.Application.Interfaces.Repositories
{


    public interface ISubscriptionRepository
    {
        Task<List<Domain.Entities.Subscriptions>> GetSubscriptionsAsync(int agencyId);
    }

}
