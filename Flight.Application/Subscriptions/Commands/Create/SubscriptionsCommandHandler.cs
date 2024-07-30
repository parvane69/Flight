using AutoMapper;
using Flight.Application.Subscriptions.Dto;
using Flight.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Application.Subscriptions.Commands.Create
{
    public class SubscriptionsCommandHandler : IRequestHandler<SubscriptionCommand, int>
    {
        private readonly FlightDbContext _db;
        private readonly IMapper _mapper;

        public SubscriptionsCommandHandler(FlightDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> Handle(SubscriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var model = _mapper.Map<List<SubscriptionInputDto>, List<Domain.Entities.Subscriptions>>(request.Items);
                await _db.Subscriptions.AddRangeAsync(model);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;

                //return OperationResult2<FoodCreateCommandResult>.BuildFailure(ex.Message);
            }

        }
    }
}
