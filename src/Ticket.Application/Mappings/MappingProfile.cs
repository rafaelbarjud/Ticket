using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Ticket.Application.Request;
using Ticket.Domain.Models;

namespace Ticket.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RequestUser, User>();
        }
    }
}
