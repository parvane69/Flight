﻿

using Flight.Application.Flights.Dto;
using Flight.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Flight.Application.Flights.Queries
{

    public class GetFlightsQueryHandler : IRequestHandler<GetFlightsQuery, List<FlightDto>>
    {
        private readonly FlightDbContext _db;

        public GetFlightsQueryHandler(FlightDbContext context)
        {
            _db = context;
        }

        public async Task<List<FlightDto>> Handle(GetFlightsQuery request, CancellationToken cancellationToken)
        {

            var subscriptions = await _db.Subscriptions
            .Where(s => s.Agency_Id == request.AgencyId)
            .ToListAsync(cancellationToken);

            var flights = await _db.Flights
            .Include(f => f.Route)
            .Where(f => f.Departure_Time >= request.StartDate && f.Departure_Time <= request.EndDate)
            .ToListAsync(cancellationToken);

            var allFlights = await _db.Flights
            .Include(f => f.Route)
            .ToListAsync(cancellationToken);

            var filteredFlights = flights
            .Where(f => subscriptions.Any(s => s.Origin_City_Id == f.Route.Origin_City_Id && s.Departure_City_Id == f.Route.Departure_City_Id))
            .Select(f => new FlightDto
            {
                FlightId = f.Id,
                OriginCityId = f.Route.Origin_City_Id,
                DestinationCityId = f.Route.Departure_City_Id,
                DepartureTime = f.Departure_Time,
                ArrivalTime = f.Arival_Time,
                AirlineId = f.Airline_Id,
                Status = DetermineStatus(f, allFlights)
            })
            .ToList();

            return filteredFlights;
        }
        private string DetermineStatus(Domain.Entities.Flights flight, List<Domain.Entities.Flights> allFlights)
        {
            var oneWeek = TimeSpan.FromDays(7);

            var isNew = !allFlights.Any(f =>
            f.Airline_Id == flight.Airline_Id &&
            f.Departure_Time >= flight.Departure_Time - oneWeek &&
            f.Departure_Time <= flight.Departure_Time - oneWeek);

            var isDiscontinued = !allFlights.Any(f =>
            f.Airline_Id == flight.Airline_Id &&
            f.Departure_Time >= flight.Departure_Time + oneWeek &&
            f.Departure_Time <= flight.Departure_Time + oneWeek);

            if (isNew)
                return "New";
            if (isDiscontinued)
                return "Discontinued";

            return "Existing";
        }
    }

}
