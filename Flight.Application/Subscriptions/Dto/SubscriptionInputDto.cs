using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;
using Flight.Application.Common;
using Flight.Application.Routes.Dto;
using MediatR;

namespace Flight.Application.Subscriptions.Dto
{
    public class SubscriptionInputDto
    {
        [Name("origin_city_id")]
        public required int Origin_City_Id { get; set; 
        }

        [Name("destination_city_id")]
        public required int Departure_City_Id { get; set; }

        [Name("agency_id")]
        public required int Agency_Id { get; set; }
    }
    public class SubscriptionCommand : IRequest<int>, ICommittableRequest
    {
        public List<SubscriptionInputDto> Items { get; set; }

    }
}
