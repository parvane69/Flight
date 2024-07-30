using Flight.Application.Subscriptions.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Flight.Application.Interfaces.Repositories
{


    public interface ISubscriptionRepository
    {
        Task<List<Domain.Entities.Subscriptions>> GetSubscriptionsAsync(int agencyId);
        Task<int> AddSubscriptions(List<Domain.Entities.Subscriptions> items);
    }

}
