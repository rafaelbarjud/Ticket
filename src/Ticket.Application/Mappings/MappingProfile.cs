using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Ticket.Application.Request;
using Ticket.Application.Response;
using Ticket.Domain.Models;

namespace Ticket.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RequestUser, User>();
            CreateMap<RequestUpdateUser, User>();
            CreateMap<RequestAddress, Address>();
            CreateMap<User, ResponseUser>();
            CreateMap<Address, ResponseAddress>();
        }
    }
}
