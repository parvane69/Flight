using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Application.Interfaces.Repositories
{
    public interface IRouteRepository
    {
        Task<int> AddRoutes(List<Domain.Entities.Routes> items);

    }
}
