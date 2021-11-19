using Hahn.ApplicatonProcess.July2021.Data.BusinessLogic;
using Hahn.ApplicatonProcess.July2021.Data.Interfaces;
using System;
using AppContext = Hahn.ApplicatonProcess.July2021.Domain.AppContext;

namespace Hahn.ApplicatonProcess.July2021.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppContext _context;

        public IUserRepository Users { get; set; }

        public IAssetRepository Assets { get; private set; }

        public UnitOfWork(AppContext context)
        {
            _context = context;
            Assets = new AssetRepository(_context);
            Users = new UserRepository(_context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        
    }
}
