using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ticket.Application.Request;
using Ticket.Application.Response;
using Ticket.Domain.Models;

namespace Ticket.Application.Interfaces
{
    public interface IApplicationServiceAddress
    {
        Task<List<Address>> GetAddress(List<RequestAddress> addresses);

        List<ResponseAddress> GetAddressByUserId(Guid userId);

        void Remove(Guid id);

        void Dispose();
    }
}
