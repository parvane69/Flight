using AutoMapper;
using Flight.Application.Subscriptions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Flight.Application.Subscriptions
{
    public class SubscriptionMapper : Profile
    {
        public SubscriptionMapper()
        {
            CreateMap<SubscriptionInputDto, Domain.Entities.Subscriptions>();
        }
    }
}
