using Flight.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Domain.Entities
{
    public class Routes : EntityBase
    {
        public required int Origin_City_Id { get; set; }
        public required int Departure_City_Id { get; set; }
        public required DateOnly Departure_Date { get; set; }

        public ICollection<Flights> Flights { get; } = new List<Flights>();

    }
}
