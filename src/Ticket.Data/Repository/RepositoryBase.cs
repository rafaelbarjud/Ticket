using Microsoft.EntityFrameworkCore;
using System;
using Ticket.Domain.Interfaces.Repository;

namespace Ticket.Data.Repository
{
    public abstract class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        private readonly SqlContext _context;

        public RepositoryBase(SqlContext context)
        {
            _context = context; 
        }

        public void Add(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public void Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {

            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
