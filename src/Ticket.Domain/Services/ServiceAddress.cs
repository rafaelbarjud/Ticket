using Ticket.Domain.Interfaces.Repository;
using Ticket.Domain.Interfaces.Services;
using Ticket.Domain.Models;

namespace Ticket.Domain.Services
{
    public class ServiceAddress : ServiceBase<Address>, IServiceAddress
    {
        public readonly IRepositoryAddress _repositoryAddress;

        public ServiceAddress(IRepositoryAddress repositoryAdress)
            : base(repositoryAdress)
        {
            _repositoryAddress = repositoryAdress;
        }
    }
}
