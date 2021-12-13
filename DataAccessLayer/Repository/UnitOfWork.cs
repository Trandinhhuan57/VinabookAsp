using DataAccessLayer.Contracts;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using System;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbcontext _context;
        private IGenericRepository<Category> _categories;
        private IGenericRepository<Flower> _flowers;

        public UnitOfWork(ApplicationDbcontext context)
        {
            _context = context;
        }

        public IGenericRepository<Category> Categories => _categories ??= new GenericRepository<Category>(_context);

        public IGenericRepository<Flower> Flowers => _flowers ??= new GenericRepository<Flower>(_context);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                _context.Dispose();
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}