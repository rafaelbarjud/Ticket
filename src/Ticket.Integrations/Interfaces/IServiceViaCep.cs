using System.Threading;
using System.Threading.Tasks;
using Ticket.Domain.Models;

namespace Ticket.Integrations.Interfaces
{
    public interface IServiceViaCep
    {
        Address Search(string zipCode);

        Task<Address> SearchAsync(string zipCode, CancellationToken cancellationToken);
    }
}
