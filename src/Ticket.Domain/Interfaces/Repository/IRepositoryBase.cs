using System;


namespace Ticket.Domain.Interfaces.Repository
{
    public  interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Dispose();
        T GetById(Guid id);
    }
}
