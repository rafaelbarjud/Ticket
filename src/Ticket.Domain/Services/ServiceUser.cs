using System;
using System.Collections.Generic;
using Ticket.Domain.Interfaces.Repository;
using Ticket.Domain.Interfaces.Services;
using Ticket.Domain.Models;

namespace Ticket.Domain.Services
{
    public class ServiceUser : ServiceBase<User>, IServiceUser
    {
        public readonly IRepositoryUser _repositoryUser;

        public ServiceUser(IRepositoryUser repositoryUser)
            : base(repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public User GetByIdWithAddress(Guid id)
        {
            return _repositoryUser.GetByIdWithAddress(id);
        }

        public List<User> GetByName(string name)
        {
            return _repositoryUser.GetByName(name);
        }
    }
}
