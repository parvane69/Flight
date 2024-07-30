using Flight.Application.Interfaces;
using MediatR.Pipeline;
using System.Threading;
using System.Threading.Tasks;

namespace Flight.Application.Common
{

    public class CommitCommandPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommitCommandPostProcessor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            if (request is ICommittableRequest)
            {
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
