using System;
using System.Collections.Generic;
using System.Text;
using Ticket.Application.Request;

namespace Ticket.Application.Interfaces
{
    public interface IApplicationServiceAddress
    {
        void Remove(Guid id);

        void Dispose();
    }
}
