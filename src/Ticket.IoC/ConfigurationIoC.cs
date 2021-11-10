using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Ticket.Application.Interfaces;
using Ticket.Application.Services;
using Ticket.Data;
using Ticket.Data.Repository;
using Ticket.Domain.Interfaces.Repository;
using Ticket.Domain.Interfaces.Services;
using Ticket.Domain.Services;
using Ticket.Integrations.Interfaces;
using Ticket.Integrations.Services;

namespace Ticket.IoC
{
    public class ConfigurationIoC
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationServiceUser>().As<IApplicationServiceUser>();
            builder.RegisterType<ApplicationServiceAddress>().As<IApplicationServiceAddress>();
            builder.RegisterType<ServiceUser>().As<IServiceUser>();
            builder.RegisterType<ServiceAddress>().As<IServiceAddress>();
            builder.RegisterType<RepositoryUser>().As<IRepositoryUser>();
            builder.RegisterType<RepositoryAddress>().As<IRepositoryAddress>();
            builder.RegisterType<ServiceViaCep>().As<IServiceViaCep>();
            builder.RegisterType<SqlContext>();
        }
    }
}
