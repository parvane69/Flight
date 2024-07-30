using AutoMapper;
using Flight.Application.Interfaces;
using Flight.Application.Subscriptions.Dto;
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
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public SubscriptionsCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(SubscriptionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var model = _mapper.Map<List<SubscriptionInputDto>, List<Domain.Entities.Subscriptions>>(request.Items);
                await _unitOfWork.SubscriptionRepository.AddSubscriptions(model);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
