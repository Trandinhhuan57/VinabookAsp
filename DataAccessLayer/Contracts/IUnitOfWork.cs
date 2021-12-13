using DataAccessLayer.Entities;
using System;
using System.Threading.Tasks;

namespace DataAccessLayer.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Category> Categories { get; }

        IGenericRepository<Flower> Flowers { get; }

        Task Save();
    }
}