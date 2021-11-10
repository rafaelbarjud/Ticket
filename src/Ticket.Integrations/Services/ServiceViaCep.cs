using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Ticket.Domain.Models;
using Ticket.Integrations.Interfaces;

namespace Ticket.Integrations.Services
{
    public class ServiceViaCep : IServiceViaCep
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ServiceViaCep> _logger;
        private readonly IConfiguration _configuration;

        public ServiceViaCep(ILogger<ServiceViaCep> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            _httpClient = HttpClientFactory.Create();
            _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("ViaCep:BaseUrl"));            
        }

        public Address Search(string zipCode)
        {
            return SearchAsync(zipCode, CancellationToken.None).Result;
        }

        public async Task<Address> SearchAsync(string zipCode, CancellationToken cancellationToken)
        {
            var url = _configuration.GetValue<string>("ViaCep:EndPoint").Replace("{zipCode}", zipCode);
            var response = await _httpClient.GetAsync(url, cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<Address>(cancellationToken).ConfigureAwait(false);
        }
    }
}
