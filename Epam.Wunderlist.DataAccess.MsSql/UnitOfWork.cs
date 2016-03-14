using System;
using DataAccess.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;

namespace DataAccess.MsSql
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            if (_context != null)
            {
                _context.SaveChanges();
                foreach (var entity in _context.ChangeTracker.Entries())
                    ((IObjectContextAdapter)_context).ObjectContext.Detach(entity.Entity);
            }

        }

        public void Dispose()
        {
            Dispose(true);
            Debug.WriteLine("Context is disposed.");
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isTrue)
        {
            if (!isTrue)
                return;
            _context?.Dispose();
        }
    }
}
