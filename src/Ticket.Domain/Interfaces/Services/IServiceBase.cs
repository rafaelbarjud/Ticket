using System;

namespace Ticket.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Dispose();
        TEntity GetById(Guid id);
    }
}
