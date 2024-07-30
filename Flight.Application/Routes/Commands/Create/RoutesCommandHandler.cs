using AutoMapper;
using Flight.Application.Interfaces;
using Flight.Application.Routes.Dto;
using Flight.Application.Subscriptions.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Application.Routes.Commands.Create
{
    public class RoutesCommandHandler : IRequestHandler<RouteCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RoutesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(RouteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var model = _mapper.Map<List<RouteInputDto>, List<Domain.Entities.Routes>>(request.Items);
                //await _db.Routes.AddRangeAsync(model);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
