using Flight.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class Subscriptions: EntityBase
    {
        public required int Origin_City_Id { get; set; }
        public required int Departure_City_Id { get; set; }
        public required int Agency_Id { get; set; }

    }

}
