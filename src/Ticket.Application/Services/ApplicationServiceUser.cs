using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using Ticket.Application.Interfaces;
using Ticket.Application.Request;
using Ticket.Application.Response;
using Ticket.Domain.Exceptions;
using Ticket.Domain.Interfaces.Services;
using Ticket.Domain.Models;


namespace Ticket.Application.Services
{
    public class ApplicationServiceUser : IApplicationServiceUser
    {
        private readonly IServiceUser _serviceUser;
        private readonly IMapper _mapper;

        public ApplicationServiceUser(IServiceUser serviceUser, IMapper mapper)
        {
            _serviceUser = serviceUser;
            _mapper = mapper;
        }

        public void Add(RequestUser user)
        {
            User newUser = _mapper.Map<User>(user);
            
            newUser.Validate(newUser);
            
            _serviceUser.Add(newUser);
        }

        public void Dispose()
        {
            _serviceUser.Dispose();
        }

        public ResponseUser GetById(Guid id)
        {
            var objUser = _serviceUser.GetById(id);
            return _mapper.Map<ResponseUser>(objUser);
        }

        public List<ResponseUser> GetByName(string name)
        {
            var objUser = _serviceUser.GetByName(name);
            return _mapper.Map<List<ResponseUser>>(objUser);
        }

        public void Remove(Guid id)
        {
            var objUser = _serviceUser.GetById(id);
            _serviceUser.Delete(objUser);
        }

        public void Update(RequestUser user)
        {
            User newUser = _mapper.Map<User>(user);
            _serviceUser.Update(newUser);
        }
    }
}
