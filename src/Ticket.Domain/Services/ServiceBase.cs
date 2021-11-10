using System;
using System.Collections.Generic;
using System.Text;
using Ticket.Domain.Interfaces.Repository;
using Ticket.Domain.Interfaces.Services;

namespace Ticket.Domain.Services
{
    public abstract class ServiceBase<T> : IDisposable, IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repositoryBase;

        public ServiceBase(IRepositoryBase<T> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public void Add(T entity)
        {
            _repositoryBase.Add(entity);
        }

        public void Delete(T entity)
        {
            _repositoryBase.Delete(entity);
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
        }

        public T GetById(Guid id)
        {
            return _repositoryBase.GetById(id);
        }

        public void Update(T entity)
        {
            try
            {
                _repositoryBase.Update(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
