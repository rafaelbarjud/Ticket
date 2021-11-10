using System;
using System.Collections.Generic;
using Ticket.Application.Request;
using Ticket.Application.Response;

namespace Ticket.Application.Interfaces
{
    public interface IApplicationServiceUser
    {
        ResponseUser Add(RequestUser user);

        ResponseUser GetById(Guid id);

        ResponseUser GetByIdWithAddress(Guid id);

        List<ResponseUser> GetByName(string name);

        ResponseUser Update(RequestUpdateUser user);

        void Remove(Guid id);

        void Dispose();
    }
}
