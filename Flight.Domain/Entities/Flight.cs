using Flight.Domain.Common;
using Flight.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class Flights : EntityBase
    {
        public required int RouteId { get; set; }
        public Routes Route { get; set; } = null!;
        public required DateTime Departure_Time { get; set; }
        public required DateTime Arival_Time { get; set; }
        public required int Airline_Id { get; set; }



    }
}
