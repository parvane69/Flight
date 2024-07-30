using CsvHelper.Configuration.Attributes;
using Flight.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Application.Routes.Dto
{
    public class RouteInputDto
    {
        
        [Name("route_id")]
        public required int Id { get; set; }

        [Name("origin_city_id")]
        public required int Origin_City_Id { get; set; }

        [Name("destination_city_id")]
        public required int Departure_City_Id { get; set; }

        [Name("departure_date")]
        public required DateOnly Departure_Date { get; set; }

    }
    public class RouteInputDtos : IRequest<int>, ICommittableRequest
    {
        public List<RouteInputDto> Items { get; set; }

    }
}
