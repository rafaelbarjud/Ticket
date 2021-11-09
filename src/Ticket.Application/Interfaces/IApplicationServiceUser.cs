using System;
using System.Collections.Generic;
using Ticket.Application.Request;
using Ticket.Application.Response;

namespace Ticket.Application.Interfaces
{
    public interface IApplicationServiceUser
    {
        void Add(RequestUser user);

        ResponseUser GetById(Guid id);
        
        List<ResponseUser> GetByName(string name);

        void Update(RequestUser user);

        void Remove(Guid id);

        void Dispose();
    }
}
