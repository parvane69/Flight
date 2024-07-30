using AutoMapper;
using Flight.Application.Routes.Dto;
using Flight.Application.Subscriptions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Application.Routes
{
    public class RouteMapper : Profile
    {
        public RouteMapper()
        {
            CreateMap<RouteInputDto, Domain.Entities.Routes>();
        }
    }
}
