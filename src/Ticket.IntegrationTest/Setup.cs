using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Ticket.Application.Interfaces;
using Ticket.Application.Services;
using Ticket.Data;
using Ticket.Data.Repository;
using Ticket.Domain.Interfaces.Repository;
using Ticket.Domain.Interfaces.Services;
using Ticket.Domain.Services;
using Ticket.Integrations.Interfaces;
using Ticket.Integrations.Services;

namespace Ticket.IntegrationTest
{
    public class Setup
    {
        private readonly IHostBuilder _defaultBuilder;
        private IServiceProvider _services;
        private bool _built = false;

        public Setup()
        {
            _defaultBuilder = Host.CreateDefaultBuilder();
        }

        public IServiceProvider Services => _services ?? Build();

        private IServiceProvider Build()
        {
            if (_built)
                throw new InvalidOperationException("Build can only be called once.");
            _built = true;

            _defaultBuilder.ConfigureServices((context, services) =>
            {
                services.AddScoped<IApplicationServiceUser, ApplicationServiceUser>();
                services.AddScoped<IApplicationServiceAddress, ApplicationServiceAddress>();
                services.AddScoped<IServiceUser, ServiceUser>();
                services.AddScoped<IServiceAddress, ServiceAddress>();
                services.AddScoped<IRepositoryUser, RepositoryUser>();
                services.AddScoped<IRepositoryAddress, RepositoryAddress>();
                services.AddScoped<IServiceViaCep, ServiceViaCep>();
                services.AddScoped<SqlContext>();
            });

            _services = _defaultBuilder.Build().Services;
            return _services;
        }
    }
}
