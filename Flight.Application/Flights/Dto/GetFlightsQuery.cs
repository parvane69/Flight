using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Application.Flights.Dto
{

    public class GetFlightsQuery : IRequest<List<FlightDto>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AgencyId { get; set; }
    }

    public class FlightDto
    {
        public int FlightId { get; set; }
        public int OriginCityId { get; set; }
        public int DestinationCityId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AirlineId { get; set; }
        public string Status { get; set; }
    }
}
