using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flight.Application.Interfaces.Repositories
{
    public interface IFlightRepository
    {
        Task<List<Domain.Entities.Flights>> GetFlightsAsync(DateTime startDate, DateTime endDate, int agencyId);
        Task<List<Domain.Entities.Flights>> GetAllFlightsAsync();
    }
}