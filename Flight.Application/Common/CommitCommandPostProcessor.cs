using Flight.Infrastructure;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Application.Common
{
    public class CommitCommandPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly FlightDbContext _db;

        public CommitCommandPostProcessor(FlightDbContext db)
        {
            _db = db;
        }

        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            if (request is ICommittableRequest)
            {
                await _db.SaveChangesAsync();
            }
            //return await next();

        }
    }
}
